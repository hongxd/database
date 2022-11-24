using System.Security.Claims;
using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NoticeController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public NoticeController(ApplicationDbContext context)
    {
        _ctx = context;
    }

    [HttpGet]
    public ActionResult<QueryResultDto<NoticeDto>> Get([FromQuery] NoticePaginableDto n)
    {
        Dictionary<string, string?> dict = new()
        {
            { "title", n.Title },
            { "noticePerson", n.NoticePerson }
        };
        var order = MapSortOrder.Map(n.Order);

        var nts = (from notice in _ctx.Notice
            join ad in _ctx.Admin on notice.PId equals ad.Id into gj
            from subAd in gj.DefaultIfEmpty()
            join dm in _ctx.Dormmanager on notice.PId equals dm.Id into gj2
            from subDm in gj2.DefaultIfEmpty()
            select new NoticeDto
            {
                Content = notice.Content,
                Date = notice.Date,
                Id = notice.Id,
                Title = notice.Title,
                NoticePerson = subAd.UserName ?? subDm.UserName,
                PId = subAd.Id ?? subDm.Id
            }).ConfigStringQuery(dict).AsNoTracking();

        if (n.Field is "date")
            nts = order switch
            {
                "asc" => nts.OrderBy(dto => dto.Date),
                "desc" => nts.OrderByDescending(dto => dto.Date),
                _ => nts
            };
        return Ok(new QueryResultDto<NoticeDto>
        {
            Result = new QueryDto<NoticeDto>
            {
                List = nts.ConfigPaging(n).ToArray(),
                Total = nts.Count()
            }
        });
    }

    [HttpGet(@"{id}")]
    public ActionResult<ResultDto<NoticeDto>> Get(Guid id)
    {
        var res = _ctx.Notice.Where(db => db.Id == id).AsNoTracking().First();
        return Ok(new ResultDto<NoticeDto>
        {
            Result = new NoticeDto
            {
                Id = res.Id,
                Content = res.Content,
                Date = res.Date,
                Title = res.Title,
                PId = res.PId
            }
        });
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(NoticeDto n)
    {
        var pid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var notice = new NoticeDb
        {
            Content = n.Content,
            Title = n.Title,
            Date = DateTime.UtcNow,
            PId = pid
        };
        await _ctx.Notice.AddAsync(notice);
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string> { Result = "成功发布此公告" });
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        requestBody.Ids.ForEach(id =>
        {
            var notice = _ctx.Notice.Single(notice => notice.Id == id);
            _ctx.Notice.Remove(notice);
        });
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "删除成功"
        });
    }
}