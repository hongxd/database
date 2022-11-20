using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = GlobalRole.Admin)]
public class DormbuildController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public DormbuildController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<QueryResultDto<DormbuildDto>> Get([FromQuery] DormbuildPaginableDto dorm)
    {
        Dictionary<string, string?> dict = new()
        {
            { "name", dorm.Name },
            { "managerName", dorm.ManagerName },
            { "detail", dorm.Detail }
        };
        var data = (from db in _ctx.Dormbuild
            join dm in _ctx.Dormmanager on db.Dormmanager equals dm.Id into gj
            from subDm in gj.DefaultIfEmpty()
            select new DormbuildPaginableDto
            {
                Detail = db.Detail,
                Dormmanager = db.Dormmanager,
                Id = db.Id,
                Name = db.Name,
                ManagerName = subDm.UserName
            }).ConfigStringQuery(dict).AsNoTracking();
        return Ok(new QueryResultDto<DormbuildDto>
        {
            Result = new QueryDto<DormbuildDto>
            {
                List = data.ConfigPaging(dorm).ToArray(),
                Total = data.Count()
            }
        });
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(Dormbuild build)
    {
        Guid? dormmanager = null;
        if (build.Dormmanager != null)
        {
            // 传的管理员id不在数据库里
            var manager = _ctx.Dormmanager.Where(dm => dm.Id == build.Dormmanager);
            if (!manager.Any()) return BadRequest("没有此管理员");
            dormmanager = manager.First().Id;
        }

        var result = "修改成功！";
        // 给宿舍分配管理员而不是给管理员分配宿舍
        if (build.Id != null)
        {
            // 传的宿舍楼id不在数据库里
            var db = _ctx.Dormbuild.Where(d => d.Id == build.Id);
            var dmn = _ctx.Dormbuild.Where(d => d.Name == build.Name);
            if (dmn.Any() && build.Name != dmn.First().Name) return BadRequest("已有相同名字的宿舍，请更换一个名字");
            if (!db.Any()) return BadRequest("错误请求");

            var d = db.First();
            d.Name = build.Name;
            d.Detail = build.Detail;
            if (dormmanager != null) d.Dormmanager = dormmanager;
        }
        else
        {
            result = "添加成功！";
            await _ctx.Dormbuild.AddAsync(build);
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
            var build = _ctx.Dormbuild.Where(dm => dm.Id == id);
            if (build.Any())
                _ctx.Dormbuild.Remove(build.First());
        });
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "删除成功！"
        });
    }
}