
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
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
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateHeadBannerDto dto)
        {
            var create = await _service.CreateAsync(dto);
            return Ok(create);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
