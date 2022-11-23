using System.Security.Claims;
using Dapper;
using database.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace database.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PasswordController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public PasswordController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<ActionResult<ResultDto<string>>> Post(PasswordDto psw)
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var role = User.FindFirstValue(ClaimTypes.Role);
        var q = await _ctx.Database.GetDbConnection().QueryFirstAsync<UserPasswordDto>(@$"select * from 
                        (select id,password from admin union 
                            select id,password from dormmanager) u 
                                where id='{id}'");
        if (psw.newPassword != psw.Password) return BadRequest("两次密码输入不一致");
        if (psw.newPassword == q.Password) return BadRequest("修改的密码不能和上次密码一致");
        if (psw.OldPassword != q.Password) return BadRequest("密码错误");
        await _ctx.Database.GetDbConnection()
            .ExecuteAsync(@$"update {role} set password='{psw.Password}' where id='{id}'");
        return Ok(new ResultDto<string>
        {
            Result = "修改成功，请重新登录"
        });
    }
}