using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Upload;

namespace Wordstag.Services.Interfaces
{
    public interface IUploadService
    {
        Task<List<GetUploadDto>> GetUpload(GetUploadDto request);
        Task<GenericList<GetUploadDto>> GetAllUpload(PaginationDto paginationDto);
        Task<Guid> SaveUpload(SaveUploadDto request);   
        Task<bool> UpdateUpload(UpdateUploadDto request);
        Task<bool> DeleteUpload(DeleteUploadDto request);
    }
}
