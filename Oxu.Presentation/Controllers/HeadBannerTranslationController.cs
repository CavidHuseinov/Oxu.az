
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.HeadbannerTranslation;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
{
    public sealed class HeadBannerTranslationController:ApiController
    {
        private readonly IHeadbannerTranslationService _service;

        public HeadBannerTranslationController(IHeadbannerTranslationService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var allData = await _service.GetAllAsync();
            return Ok(allData);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateHeadbannerTranslationDto dto)
        {
            var data = await _service.CreateAsync(dto);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
