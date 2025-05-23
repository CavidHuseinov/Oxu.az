
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.NewsTranslation;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
{
    public class NewsTranslationController:ApiController
    {
        private readonly INewsTranslationService _service;

        public NewsTranslationController(INewsTranslationService service)
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
        public async Task<IActionResult> CreateAsync(CreateNewsTranslationDto dto)
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
