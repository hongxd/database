using System.Security.Claims;
using database.Dto;
using database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace database.Controllers
{
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
        public ActionResult<ResultDto<List<NoticeDto>?>> Get()
        {
            var nts = from notice in _ctx.Set<Notice>()
                join admin in _ctx.Set<Admin>()
                    on notice.PId equals admin.Id
                select new NoticeDto()
                {
                    Id = notice.Id, 
                    NoticePerson = admin.UserName,
                    Content = notice.Content,
                    Date = notice.Date,
                    PId = admin.Id
                };
            return Ok(new ResultDto<List<NoticeDto>?>()
            {
                Result = nts.ToList()
            });
        }

        [HttpGet(@"{id}")]
        public ActionResult<ResultDto<Notice?>> Get(Guid id)
        {
            return Ok(_ctx.Notice.Single(notice => notice.Id == id));
        }

        [HttpPut]
        public async Task<ActionResult<ResultDto<string>>> Put(ContentDto c)
        {
            var pid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var notice = new Notice()
            {
                Content = c.Content,
                Date = DateTime.Now,
                PId = pid
            };
            await _ctx.Notice.AddAsync(notice);
            await _ctx.SaveChangesAsync();
            return Ok(new ResultDto<string>() { Result = "添加成功" });
        }

        [HttpDelete]
        public async Task<ActionResult<ResultDto<string>>> Delete(IdsDto requestBody)
        {
            try
            {
                requestBody.Ids.ForEach(id =>
                {
                    var notice = _ctx.Notice.Single(notice => notice.Id == id);
                    _ctx.Notice.Remove(notice);
                });
                await _ctx.SaveChangesAsync();
                return Ok(new ResultDto<string>()
                {
                    Result = "删除成功",
                });
            }
            catch
            {
                return BadRequest("无法删除不存在的公告！");
            }
        }
    }
}
