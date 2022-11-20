using System.Security.Claims;
using database.Dto;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static database.Utils.Gender;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PersonalCenterController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public PersonalCenterController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<ResultDto<PersonDto>> Get()
    {
        var id = Guid.Parse((ReadOnlySpan<char>)User.FindFirstValue(ClaimTypes.NameIdentifier));
        var role = User.FindFirstValue(ClaimTypes.Role);
        switch (role)
        {
            case GlobalRole.Admin:
            {
                var p = _ctx.Admin.Single(admin => admin.Id == id);
                return Ok(new ResultDto<PersonDto>
                {
                    Result = new PersonDto
                    {
                        Name = p.Name,
                        Sex = p.Sex,
                        Tel = p.Tel,
                        Username = p.UserName,
                        Role = "admin"
                    }
                });
            }
            case GlobalRole.DormManager:
            {
                var p = _ctx.Dormmanager.Single(dm => dm.Id == id);
                var d = _ctx.Dormbuild.Single(d => d.Id == p.DormBuildId);
                return Ok(new ResultDto<PersonDto>
                {
                    Result = new PersonDto
                    {
                        Name = p.Name,
                        Sex = p.Sex,
                        Tel = p.Tel,
                        Username = p.UserName,
                        DormBuildName = d.Name,
                        DormBuildDetail = d.Detail,
                        Role = "dormmanager"
                    }
                });
            }
            case GlobalRole.Student:
            {
                var p = _ctx.Student.Single(dm => dm.Id == id);
                var d = _ctx.Dormbuild.Single(d => d.Id == p.DormBuildId);
                return Ok(new ResultDto<PersonDto>
                {
                    Result = new PersonDto
                    {
                        Name = p.Name,
                        Sex = p.Sex,
                        Tel = p.Tel,
                        Username = p.StuNum,
                        DormBuildName = d.Name,
                        DormBuildDetail = d.Detail,
                        Role = "student"
                    }
                });
            }
            default:
                return BadRequest("请检查是否已经登录");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ResultDto<string>>> Post(PersonDto p)
    {
        // 这里不允许修改宿舍的信息，宿舍的信息只能由管理员修改
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var role = User.FindFirstValue(ClaimTypes.Role);
        if (p.Sex is not (Male or Female)) return BadRequest("性别只能为男或女");
        switch (role)
        {
            case GlobalRole.Admin:
            {
                var admin = _ctx.Admin.Single(admin => admin.Id == id);
                admin.UserName = p.Username;
                admin.Sex = p.Sex;
                admin.Name = p.Name;
                admin.Tel = p.Tel;
                break;
            }
            case GlobalRole.DormManager:
            {
                var dm = _ctx.Dormmanager.Single(dm => dm.Id == id);
                dm.UserName = p.Username;
                dm.Name = p.Name;
                dm.Sex = p.Sex;
                dm.Tel = p.Tel;
                break;
            }
            case GlobalRole.Student:
            {
                var stu = _ctx.Student.Single(student => student.Id == id);
                if (stu.StuNum != p.Username) return BadRequest("学生的用户名只能为学生的学号");
                stu.Name = p.Name;
                stu.Sex = p.Sex;
                stu.Tel = p.Tel;
                break;
            }
        }

        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "成功修改个人信息！"
        });
    }
}