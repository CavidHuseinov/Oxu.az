
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.CategoryTranslation;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
{
    public class CategoryTranslationController:ApiController
    {
        private readonly ICategoryTranslationService _service;

        public CategoryTranslationController(ICategoryTranslationService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public async Task<ActionResult> GetAllAsync()
        {
            var allData = await _service.GetAllTranslationsAsync();
            return Ok(allData);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var dataId = await _service.GetByIdAsync(id);
            return Ok(dataId);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryTranslationDto dto)
        {
            var newData = await _service.CreateAsync(dto);
            return Ok(newData);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
