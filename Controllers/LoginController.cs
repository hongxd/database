using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dapper;
using database.Dto;
using database.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var secBytes = Encoding.UTF8.GetBytes(key ?? throw new InvalidOperationException());
        var secKey = new SymmetricSecurityKey(secBytes);
        var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expires,
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    [HttpPost]
    public async Task<ActionResult<ResultDto<LoginResultDto>>> Post(UserDto user)
    {
        switch (user.RoleId)
        {
            // 管理员登录
            case Role.Manager:
            {
                var sql =
                    $"""
                         select * from 
                            (select "userName", password, id, 'admin' role from admin union
                                select "userName", password, id, 'dormmanager' role from dormmanager) u
                                    where u."userName" = '{ user.Username} ' and u.password = '{ user.Password} '
                         """ ;
                var u = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<User>(sql);
                if (u == null) return BadRequest("用户名或密码错误");

                return Ok(new ResultDto<LoginResultDto>
                {
                    Result = new LoginResultDto
                    {
                        Token = GetToken(u.Id, u.Username, u.Role)
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