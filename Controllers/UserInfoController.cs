using System.Security.Claims;
using database.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static database.Utils.GlobalRole;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserInfoController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public UserInfoController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public async Task<ActionResult<ResultDto<UserInfoDto>>> Get()
    {
        var id = Guid.Parse((ReadOnlySpan<char>)User.FindFirstValue(ClaimTypes.NameIdentifier));
        var role = User.FindFirstValue(ClaimTypes.Role);
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        switch (role)
        {
            case Admin:
            {
                var admin = _ctx.Admin.Single(ad => ad.Id == id);
                return Ok(new ResultDto<UserInfoDto>
                {
                    Result = new UserInfoDto
                    {
                        Id = id,
                        Username = admin.UserName,
                        Name = admin.Name,
                        Token = accessToken,
                        Roles = new List<Roles> { new() { RoleName = admin.UserName, Value = Admin } }
                    }
                });
            }
            case DormManager:
            {
                var dm = _ctx.Dormmanager.Single(dm => dm.Id == id);
                return Ok(new ResultDto<UserInfoDto>
                {
                    Result = new UserInfoDto
                    {
                        Id = id,
                        Username = dm.UserName,
                        Name = dm.Name,
                        Token = accessToken,
                        Roles = new List<Roles> { new() { RoleName = dm.UserName, Value = DormManager } }
                    }
                });
            }
        }

        return BadRequest("错误请求");
    }
}