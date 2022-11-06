using System.Security.Claims;
using database.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers
{
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
            switch (role)
            {
                case "admin":
                {
                    var admin = _ctx.Admin.Single(ad => ad.Id == id);
                    var accessToken = await HttpContext.GetTokenAsync("access_token");
                    return Ok(new ResultDto<UserInfoDto>()
                    {
                        Result = new UserInfoDto()
                        {
                            Id = id,
                            Username = admin.UserName,
                            Name = admin.Name,
                            Password = admin.Password,
                            Token = accessToken,
                            Roles = new List<Roles> { new() { RoleName = admin.UserName, Value = "admin" } },
                        }
                    });
                }
            }

            return BadRequest("错误请求");
        }
    }
}
