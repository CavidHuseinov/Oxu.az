using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.FileUpload;

namespace Oxu.WebAPI.ExternalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _service;
        private readonly IWebHostEnvironment _env;

        public FileUploadController(IFileUploadService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }
        [HttpPost("uploads")]
        public async Task<IActionResult> FileUploadAsync(FileUploadDto dto)
        {
            try
            {
                var result = await _service.FileUploadAsync(dto, _env.WebRootPath);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
