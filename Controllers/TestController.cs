using database.Dto;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public TestController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public ActionResult<ResultDto<string>> Get()
    {
        return Ok(new ResultDto<string>
        {
            Result = "成功"
        });
    }
}