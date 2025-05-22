
using Microsoft.AspNetCore.Http;

namespace Oxu.Domain.DTOs.FileUpload
{
    public record FileUploadDto
    {
        public IFormFile File { get; set; } = default!;
        public string FolderName { get; set; } = default!;
    }
}
