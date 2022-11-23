using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepairController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public RepairController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<ResultDto<QueryDto<RepairDto>>> Get([FromQuery] RepairPaginableDto repair)
    {
        Dictionary<string, string?> dict = new()
        {
            { "thing", repair.Thing },
            { "detail", repair.Detail },
            { "dormitoryName", repair.DormitoryName }
        };
        var q = (from rp in _ctx.Repair
                join d in _ctx.Dormitory on rp.DormitoryId equals d.Id into gj
                from subD in gj.DefaultIfEmpty()
                join db in _ctx.Dormbuild on subD.DormBuildId equals db.Id into gj2
                from subDb in gj2.DefaultIfEmpty()
                select new RepairDto
                {
                    Detail = rp.Detail,
                    Id = rp.Id,
                    Status = rp.Status,
                    Thing = rp.Thing,
                    ReportTime = rp.ReportTime,
                    DormitoryId = subD.Id,
                    DormitoryName = subDb.Name + "--" + subD.Name
                }).ConfigStringQuery(dict).ConfigEqualSingleQuery("status", repair.Status).ConfigPaging(repair)
            .AsNoTracking();
        return Ok(new ResultDto<QueryDto<RepairDto>>
        {
            Result = new QueryDto<RepairDto>
            {
                List = q.ToArray(),
                Total = q.Count()
            }
        });
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(Repair repair)
    {
        // clock.PId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        // await _ctx.Punchclock.AddAsync(clock);
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "添加成功！"
        });
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        requestBody.Ids.ForEach(id =>
        {
            var repair = _ctx.Repair.SingleOrDefault(rp => rp.Id == id);
            if (repair == null) return;
            _ctx.Repair.Remove(repair);
        });
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "删除成功"
        });
    }
}