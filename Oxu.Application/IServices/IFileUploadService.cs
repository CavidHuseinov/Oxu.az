
using Oxu.Domain.DTOs.FileUpload;

namespace Oxu.Application.IServices
{
    public interface IFileUploadService
    {
        Task<FileUrlDto> FileUploadAsync(FileUploadDto fileUploadDto, string webRootPath);
    }
}
