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

    //[HttpGet]
    //public ActionResult<ResultDto<string>> Get()
    //{

    //}
}