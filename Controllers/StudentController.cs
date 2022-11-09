using database.Dto;
using database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    public ActionResult<ResultDto<List<Student>>> Get([FromQuery] StudentDto stu)
    {
        var role = User.FindFirstValue(ClaimTypes.Role);
        switch (role)
        {
            case "admin":
                Console.WriteLine(stu.PageSize);
                return Ok(new ResultDto<List<Student>>
                {
                    Result = _ctx.Student.ToList(),
                });
            case "dormmanager":
                {
                    // 管理员只能查看自己管理宿舍里的学生(最多管理一栋宿舍)
                    var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var dm = _ctx.Dormmanager.Single(dm => dm.Id == id);
                    var stus = _ctx.Student.Where(student => student.DormBuildId == dm.DormBuildId);
                    return Ok(new ResultDto<List<Student>>
                    {
                        Result = stus.ToList()
                    });
                }
            default:
                return Unauthorized("没有权限访问");
        }
    }

    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<ResultDto<string>>> Put(Student stu)
    {
        await _ctx.Student.AddAsync(stu);
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "添加成功！"
        });
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        try
        {
            //var query =
            //    from student in _ctx.Student
            //    where requestBody.Ids.Contains(student.Id)
            //    select new Student();
            requestBody.Ids.ForEach(id =>
            {
                var student = _ctx.Student.Single(dm => dm.Id == id);
                _ctx.Student.Remove(student);
            });
            //var stu = _ctx.Student.Where(dm => requestBody.Ids.Contains(dm.Id));
            //_ctx.Remove(query);
            await _ctx.SaveChangesAsync();
            return Ok(new ResultDto<string>
            {
                Result = "删除成功！"
            });
        }
        catch
        {
            return BadRequest("无法删除不存在的学生！");
        }
    }
}