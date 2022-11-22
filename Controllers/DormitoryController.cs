using database.Dto;
using database.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DormitoryController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public DormitoryController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<QueryResultDto<DormitoryDto>> Get([FromQuery] DormitoryPaginableDto d)
    {
        Dictionary<string, string?> dict = new()
        {
            { "name", d.Name }
        };

        var data = (from dor in _ctx.Dormitory
            where d.DormBuildId == null || d.DormBuildId == dor.DormBuildId
            join db in _ctx.Dormbuild on dor.DormBuildId equals db.Id into gj
            from subDb in gj.DefaultIfEmpty()
            select new DormitoryDto
            {
                Id = dor.Id,
                Name = dor.Name,
                DormBuildId = dor.DormBuildId,
                DormBuildName = subDb.Name
            }).ConfigStringQuery(dict).AsNoTracking();

        return Ok(new QueryResultDto<DormitoryDto>
        {
            Result = new QueryDto<DormitoryDto>
            {
                List = data.ConfigPaging(d).ToArray(),
                Total = data.Count()
            }
        });
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(DormitoryDto d)
    {
        var any = _ctx.Dormitory.Any(dormitory => dormitory.DormBuildId == d.DormBuildId && dormitory.Name == d.Name);
        if (d.Id == null)
        {
            if (any) return BadRequest("该楼宇已存在相同名字寝室");
            await _ctx.Dormitory.AddAsync(d);
            await _ctx.SaveChangesAsync();
            return Ok("添加成功");
        }

        var self = await _ctx.Dormitory.SingleOrDefaultAsync(dormitory => dormitory.Id == d.Id);
        if (self == null) return BadRequest("错误请求");
        if (d.Name != self.Name && any) return BadRequest("该楼宇已存在相同名字寝室");
        self.Name = d.Name;
        self.DormBuildId = d.Id;
        await _ctx.SaveChangesAsync();
        return Ok("修改成功");
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        requestBody.Ids.ForEach(id =>
        {
            var d = _ctx.Dormitory.Single(notice => notice.Id == id);
            _ctx.Dormitory.Remove(d);
        });
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "删除成功"
        });
    }
}