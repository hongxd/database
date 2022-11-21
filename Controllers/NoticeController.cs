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
    public ActionResult<ResultDto<NoticeDto[]>> Get([FromQuery] NoticePaginableDto n)
    {
        Dictionary<string, string?> dict = new()
        {
            { "title", n.Title },
            { "noticePerson", n.NoticePerson }
            // { "date", n.Date.ToString() }
        };

        var nts = _ctx.NoticeDto
            .FromSqlRaw(@"select distinct Pid, content, date, noticePerson, title, n.id
            from notice n
            left join (select id, userName noticePerson
                    from admin
                    union
                    select id, userName
                    from dormmanager) as u
                   ON u.id = n.Pid")
            .ConfigStringQuery(dict).ConfigPaging(n).AsNoTracking();
        return Ok(new ResultDto<NoticeDto[]>
        {
            Result = nts.ToArray()
        });
    }

    [HttpGet(@"{id}")]
    public ActionResult<ResultDto<NoticeDb>> Get(Guid id)
    {
        return Ok(_ctx.Notice.Single(notice => notice.Id == id));
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(ContentDto c)
    {
        var pid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var notice = new NoticeDb
        {
            Content = c.Content,
            Date = DateTime.Now,
            PId = pid
        };
        await _ctx.Notice.AddAsync(notice);
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string> { Result = "添加成功" });
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        try
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
        catch
        {
            return BadRequest("无法删除不存在的公告！");
        }
    }
}