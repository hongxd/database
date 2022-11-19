using database.Dto;
using database.Entities;
using database.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<QueryResultDto<Dormmanager>> Get([FromQuery] ManagerDto dm)
    {
        var whereExp = Query.ConfigQuery(dm);
        var data = _ctx.Dormmanager.FromSqlRaw(@$"select * from dormmanager {whereExp}");
        var manager = Query.ConfigPaging(data, dm).ToArray();
        return Ok(new QueryResultDto<Dormmanager>
            {
                Result = new QueryDto<Dormmanager>
                {
                    List = manager,
                    Total = data.Count()
                }
            }
        );
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto<string>>> Put(ManagerDto dm)
    {
        // 给宿舍添加管理员而不是给管理员添加宿舍
        var res = @$"添加宿舍管理员成功，默认密码为{UserValue.DmPassword}";
        var duplicate = _ctx.Dormmanager.Any(dormmanager => dormmanager.UserName == dm.UserName);
        if (dm.Id == null)
        {
            if (duplicate) return BadRequest("此用户名已被使用，请考虑更换别的用户名");
            //添加宿舍管理员
            dm.Password = UserValue.DmPassword;
            await _ctx.Dormmanager.AddAsync(dm);
        }
        else
        {
            var self = _ctx.Dormmanager.Single(dormmanager => dormmanager.Id == dm.Id);
            self.Name = dm.Name;
            self.Sex = dm.Sex;
            self.Tel = dm.Tel;
            if (self.UserName != dm.UserName && duplicate) return BadRequest("此用户名已被使用，请考虑更换别的用户名");
            self.UserName = dm.UserName;
            res = @"成功修改宿舍管理员信息";
        }

        await _ctx.SaveChangesAsync();
        return Ok(new ResultDto<string>
        {
            Result = res
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