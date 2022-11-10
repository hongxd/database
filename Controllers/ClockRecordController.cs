using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClockRecordController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;
}