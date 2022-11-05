using database.Dto;
using database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DormbuildController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public DormbuildController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<ResultDto<List<Dormbuild>>> Get()
        {
            return Ok(new ResultDto<List<Dormbuild>>()
            {
                Data = _ctx.Dormbuild.ToList()
            });
        }

        [HttpPut]
        public async Task<ActionResult<ResultDto<string>>> Put(Dormbuild build)
        {
            await _ctx.Dormbuild.AddAsync(build);
            await _ctx.SaveChangesAsync();
            return Ok(new ResultDto<string>()
            {
                Data = "添加成功！"
            });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        // 给宿舍楼分配管理员
        public async Task<ActionResult<ResultDto<string>>> Post(DistributeManagerDto info)
        {
            try
            {
                var dm = _ctx.Dormmanager.Single(dm => dm.Id == info.DormbuildId);
                dm.DormBuildId = info.DormbuildId;
                await _ctx.SaveChangesAsync();
                return Ok(new ResultDto<string>()
                {
                    Data = "成功修改" + dm.Name + "管理的宿舍楼",
                });
            }
            catch
            {
                return BadRequest("不存在此宿舍楼");
            }


        }

        [HttpDelete]
        public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
        {
            try
            {
                requestBody.Ids.ForEach(id =>
                {
                    var build = _ctx.Dormbuild.Single(dm => dm.Id == id);
                    _ctx.Dormbuild.Remove(build);
                });
                await _ctx.SaveChangesAsync();
                return Ok(new ResultDto<string>()
                {
                    Data = "删除成功！"
                });
            }
            catch
            {
                return BadRequest("无法删除不存在的宿舍楼！");
            }
        }
    }
}
