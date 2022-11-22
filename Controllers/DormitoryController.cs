using database.Dto;
using database.Utils;
using Microsoft.AspNetCore.Mvc;

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
            select new DormitoryDto
            {
                Id = dor.Id,
                Name = dor.Name,
                DormBuildId = dor.DormBuildId
            }).ConfigStringQuery(dict);
        if (d.DormBuildId != null)
            // 根据宿舍楼宇id获取宿舍
            data = data.Where(dormitory => dormitory.DormBuildId == d.DormBuildId);

        return Ok(new QueryResultDto<DormitoryDto>
        {
            Result = new QueryDto<DormitoryDto>
            {
                List = data.ConfigPaging(d).ToArray(),
                Total = data.Count()
            }
        });
    }
}