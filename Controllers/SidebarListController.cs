using System.Security.Claims;
using database.Dto;
using database.Utils;
using database.Utils.SidebarList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static database.Utils.GlobalRole;
using static database.Utils.SidebarList.SidebarList;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SidebarListController : ControllerBase
{
    [HttpGet]
    public ResultDto<List<Sidebar>> Get()
    {
        var role = User.FindFirstValue(ClaimTypes.Role);
        return role switch
        {
            GlobalRole.Admin => new ResultDto<List<Sidebar>> { Result = Admin() },
            DormManager => new ResultDto<List<Sidebar>> { Result = Dormmanager() },
            _ => throw new Exception("用户信息异常[GetSidebarListController]")
        };
    }
}