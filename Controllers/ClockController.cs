using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClockController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public ClockController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<ResultDto<List<Punchclock>>> Get()
    {
        return Ok(new ResultDto<List<Punchclock>>
        {
            // Result = _ctx.Punchclock.ToList(),
        });
    }

    [HttpPut]
    [Authorize(Roles = GlobalRole.Admin)]
    public async Task<ActionResult<ResultDto<string>>> Put(Punchclock clock)
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
    [Authorize(Roles = GlobalRole.Admin)]
    public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
    {
        try
        {
            requestBody.Ids.ForEach(id =>
            {
                // var punchclock = _ctx.Punchclock.Single(pc => pc.Id == id);
                // _ctx.Punchclock.Remove(punchclock);
            });
            await _ctx.SaveChangesAsync();
            return Ok(new ResultDto<string>
            {
                Result = "删除成功"
            });
        }
        catch
        {
            return BadRequest("无法删除不存在的记录！");
        }
    }
}