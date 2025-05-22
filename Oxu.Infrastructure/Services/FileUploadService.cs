
using Oxu.Application.Extensions;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.FileUpload;

namespace Oxu.Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {

        public async Task<FileUrlDto> FileUploadAsync(FileUploadDto fileUploadDto, string webRootPath)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
                throw new ArgumentNullException(nameof(fileUploadDto.File), $"Yuklediyiniz fayl tapilmadi ve ya cox kicikdir.");
            if (fileUploadDto.FolderName == null)
                throw new ArgumentNullException(nameof(fileUploadDto.File), $"Qovluq adi teyin edin.");

            string imgUrl = await fileUploadDto.File.UploadAsync(webRootPath, fileUploadDto.FolderName);

            return new FileUrlDto
            {
                Url = imgUrl,
            };
        }

    }
}
