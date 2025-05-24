
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Reactions;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
{
    public class ReactionController:ApiController
    {
        private readonly IReactionService _service;

        public ReactionController(IReactionService service)
        {
            _service = service;
        }
        [HttpPost("add-reactions")]
        public async Task<IActionResult> AddReactions(CreateReactionsDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Bilinmir";
            var userAgent = Request.Headers["User-Agent"].ToString();
            await _service.AddReactionAsync(dto,ipAddress,userAgent);
            return Ok("Elave olundu");
        }
        [HttpGet("{newsId}/reactions")]
        public async Task<IActionResult> GetReactionsByNews(Guid newsId)
        {
            var reactions = await _service.GetRactionsByNewsAsync(newsId);
            return Ok(reactions);
        }
    }
}
