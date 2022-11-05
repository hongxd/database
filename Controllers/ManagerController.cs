﻿using database.Dto;
using database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public ManagerController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<ResultDto<List<Dormmanager>>> Get()
        {
            return Ok(new ResultDto<List<Dormmanager>>()
                {
                    Data = _ctx.Dormmanager.ToList()
                }
            );
        }

        [HttpPut]
        public async Task<ActionResult<ResultDto<string>>> Put(Dormmanager dormmanager)
        {
            await _ctx.Dormmanager.AddAsync(dormmanager);
            await _ctx.SaveChangesAsync();
            return Ok(new ResultDto<string>()
            {
                Data = "添加成功！",
            });
        }

        [HttpDelete]
        public async Task<ActionResult<ResultDto<string>>> Delete([FromBody]IdsDto requestBody)
        {
            try
            {
                requestBody.Ids.ForEach(id =>
                {
                    var dm = _ctx.Dormmanager.Single(dm => dm.Id == id);
                    _ctx.Dormmanager.Remove(dm);
                });
                await _ctx.SaveChangesAsync();
                return Ok(new ResultDto<string>()
                {
                    Data = "删除成功！"
                });
            }
            catch
            {
                return BadRequest("无法删除不存在的管理员！");
            }
            
        }
    }
}
