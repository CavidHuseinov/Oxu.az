
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.TagTranslation;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
{
    public class TagTranslationController:ApiController
    {
        private readonly ITagTranslationService _service;

        public TagTranslationController(ITagTranslationService service)
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
        public async Task<IActionResult> CreateAsync(CreateTagTranslationDto dto)
        {
            var data = await _service.CreateAsync(dto);
            return Ok(data);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
