
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;

namespace Oxu.Presentation.Abstractions
{
    public sealed class HeadbannerController:ApiController
    {
        private readonly IHeadBannerService _service;

        public HeadbannerController(IHeadBannerService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(data);
        }
    }
}
