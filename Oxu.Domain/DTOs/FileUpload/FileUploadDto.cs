
using Microsoft.AspNetCore.Http;

namespace Oxu.Domain.DTOs.FileUpload
{
    public record FileUploadDto(IFormFile File , string FolderName);
}
