
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Tag;
using Oxu.Presentation.Abstractions;

namespace Oxu.Presentation.Controllers
{
    public class TagController:ApiController
    {
        private readonly ITagService _service;

        public TagController(ITagService service)
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
            var dataId = await _service.GetByIdAsync(id);
            return Ok(dataId);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateTagDto dto)
        {
            var createData = await _service.CreateAsync(dto);
            return Ok(createData);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
