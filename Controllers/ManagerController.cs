using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = GlobalRole.Admin)]
public class ManagerController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public ManagerController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<QueryResultDto<Dormmanager>> Get()
    {
        var manager = _ctx.Dormmanager.ToArray();
        return Ok(new QueryResultDto<Dormmanager>
        {
            Result = new QueryDto<Dormmanager>
            {
                List = manager,
                Total = manager.Length
            }
        }
        );
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(Dormmanager dormmanager)
    {
        await _ctx.Dormmanager.AddAsync(dormmanager);
        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = "添加成功！",
        });
    }

    [HttpDelete]
    public async Task<ActionResult<ResultDto<string>>> Delete([FromBody] IdsDto requestBody)
    {
        try
        {
            requestBody.Ids.ForEach(id =>
            {
                var dm = _ctx.Dormmanager.Single(dm => dm.Id == id);
                _ctx.Dormmanager.Remove(dm);
            });
            await _ctx.SaveChangesAsync();
            return Ok(new ResultDto<string>
            {
                Result = "删除成功！"
            });
        }
        catch
        {
            return BadRequest("无法删除不存在的管理员！");
        }

    }
}