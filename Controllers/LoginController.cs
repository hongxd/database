using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using database.Dto;
using database.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static database.Utils.GlobalRole;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IOptionsSnapshot<JwtHelper> _jwt;

    public LoginController(ApplicationDbContext ctx, IOptionsSnapshot<JwtHelper> jwt)
    {
        _context = ctx;
        _jwt = jwt;
    }

    private string GetToken(Guid? id, string? name, string role)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, id.ToString()),
            new(ClaimTypes.Name, name),
            new(ClaimTypes.Role, role)
        };
        var key = _jwt.Value.SecKey;
        var expires = DateTime.Now.AddSeconds(_jwt.Value.ExpireSeconds);
        var secBytes = Encoding.UTF8.GetBytes(key);
        var secKey = new SymmetricSecurityKey(secBytes);
        var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expires,
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    [HttpPost]
    public ActionResult<ResultDto<LoginResultDto>> Post(UserDto user)
    {
        switch (user.RoleId)
        {
            // 管理员登录
            case Role.Manager:
            {
                var adm = _context.Admin
                    .Where(admin => admin.UserName == user.Username && admin.Password == user.Password)
                    .ToList();
                var manager = _context.Dormmanager
                    .Where(dm => dm.UserName == user.Username && dm.Password == user.Password)
                    .ToList();
                if (!adm.Any() && !manager.Any()) return BadRequest("用户名或密码错误");

                Guid? id;
                string role;
                string? name;
                if (adm.Any())
                {
                    id = adm.First().Id;
                    role = Admin;
                    name = adm.First().UserName;
                }
                else
                {
                    id = manager.First().Id;
                    role = DormManager;
                    name = manager.First().UserName;
                }

                return Ok(new ResultDto<LoginResultDto>
                {
                    Result = new LoginResultDto
                    {
                        Token = GetToken(id, name, role)
                    }
                });
            }
            // 学生登录
            case Role.Student:
            {
                var stu = _context.Student
                    .Where(student => student.StuNum == user.Username && student.Password == user.Password)
                    .ToList();
                if (stu.Count == 0) return BadRequest("用户名或密码错误");
                return Ok(new ResultDto<LoginResultDto>
                {
                    Result = new LoginResultDto
                    {
                        Token = GetToken(stu.First().Id, stu.First().Name, Student)
                    }
                });
            }
            default:
                return BadRequest("不存在此角色");
        }
    }
}