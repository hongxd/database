using System.Security.Claims;
using Dapper;
using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static database.Utils.Query;

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
    public async Task<ActionResult<QueryResultDto<NoticeDto>>> Get([FromQuery] NoticePaginableDto n)
    {
        Dictionary<string, string?> dict = new()
        {
            { "title", n.Title },
            { "noticePerson", n.NoticePerson }
        };
        var order = MapSortOrder.Map(n.Order);

        var where = GenerateWhere(dict);
        var paging = GeneratePaging(n, n.Field ?? "date", order);
        var sql = @$"select Pid,title,date,noticePerson,n.id,null as content
                        from notice n
                        left join (select id, userName noticePerson
                                from admin
                                union
                                select id, userName
                                from dormmanager) as p
                               ON p.id = n.Pid {where} {paging}";
        Console.WriteLine(sql);
        var selectCountSql = SelectCountSql("notice", where);
        Console.WriteLine(selectCountSql);
        var count = (await _ctx.Database.GetDbConnection().QueryAsync<int>(selectCountSql)).First();
        // 这里不传content
        var nts = await _ctx.Database.GetDbConnection().QueryAsync<NoticeDto>(sql);
        var noticeDtos = nts as NoticeDto[] ?? nts.ToArray();
        return Ok(new QueryResultDto<NoticeDto>
        {
            Result = new QueryDto<NoticeDto>
            {
                List = noticeDtos.ToArray(),
                Total = count
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
            Date = DateTime.Now,
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