using System.Security.Claims;
using database.Dto;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static database.Utils.GlobalRole;
using static database.Utils.UserValue;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public StudentController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<QueryResultDto<StudentDto>> Get([FromQuery] StudentPaginableDto stu)
    {
        var role = User.FindFirstValue(ClaimTypes.Role);
        Dictionary<string, string?> dict = new()
        {
            { "stuNum", stu.StuNum },
            { "name", stu.Name },
            { "tel", stu.Tel },
            { "dormName", stu.DormName }
        };
        var data = (from s in _ctx.Student
            join db in _ctx.Dormbuild on s.DormBuildId equals db.Id into gj
            from subDb in gj.DefaultIfEmpty()
            select new StudentPaginableDto
            {
                Id = s.Id,
                Name = s.Name,
                Sex = s.Sex,
                Tel = s.Tel,
                DormBuildId = subDb.Id,
                StuNum = s.StuNum,
                DormName = subDb.Name
            }).ConfigStringQuery(dict).ConfigEqualSingleQuery("sex", stu.Sex).AsNoTracking();

        switch (role)
        {
            case Admin:
                var list = data.ConfigPaging(stu).ToArray();
                return Ok(new QueryResultDto<StudentDto>
                {
                    Result = new QueryDto<StudentDto>
                    {
                        List = list,
                        Total = data.Count()
                    }
                });
            case DormManager:
            {
                // 管理员只能查看自己管理宿舍里的学生(最多管理一栋宿舍)
                var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var dm = _ctx.Dormmanager.Single(dm => dm.Id == id);
                // var stus = data.Where(student => student.DormBuildId == dm.DormBuildId);
                return Ok(new QueryResultDto<StudentPaginableDto>
                {
                    Result = new QueryDto<StudentPaginableDto>
                    {
                        List = data.ConfigPaging(stu).ToArray(),
                        Total = data.Count()
                    }
                });
            }
            default:
                return Unauthorized("没有权限访问");
        }
    }

    [HttpPut]
    [Authorize(Roles = Admin)]
    public async Task<ActionResult<ResultDto<string>>> Put(StudentPaginableDto stu)
    {
        var id = stu.DormBuildId;
        var sno = stu.StuNum;
        var result = @$"添加成功！默认密码为{DefaultPassword}";
        // 提供id是修改模式，不提供id是删除模式
        if (stu.Id == null)
        {
            var student = _ctx.Student.Where(s => s.StuNum == sno);
            if (student.Any())
                // 执行修改操作
                return BadRequest("已存在相同学号学生！");
            stu.Password = DefaultPassword;
            var dorm = _ctx.Dormbuild.Where(db => db.Id == id);
            if (!dorm.Any())
                return BadRequest("不存在此宿舍！");
            await _ctx.Student.AddAsync(stu);
        }
        else
        {
            var dorm = _ctx.Dormbuild.Where(db => db.Id == id);
            if (!dorm.Any())
                return BadRequest("不存在此宿舍！");
            var student = _ctx.Student.Single(s => s.Id == stu.Id);
            student.Name = stu.Name;
            student.Sex = stu.Sex;
            student.StuNum = stu.StuNum;
            student.Tel = stu.Tel;
            student.DormBuildId = stu.DormBuildId;
            result = @"修改成功!";
        }

        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = result
        });
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        requestBody.Ids.ForEach(id =>
        {
            var student = _ctx.Student.Single(dm => dm.Id == id);
            _ctx.Student.Remove(student);
        });
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "删除成功！"
        });
    }
}