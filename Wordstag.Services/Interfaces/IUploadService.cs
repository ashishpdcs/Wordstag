using Wordstag.Services.Entities.Upload;

namespace Wordstag.Services.Interfaces
{
    public interface IUploadService
    {
        Task<List<GetUploadDto>> GetUpload(GetUploadDto request);
        Task<List<GetUploadDto>> GetAllUpload();
        Task<Guid> SaveUpload(SaveUploadDto request);   
        Task<bool> UpdateUpload(UpdateUploadDto request);
        Task<bool> DeleteUpload(DeleteUploadDto request);
        Task<List<GetUploadDto>> GetUserUpload(Guid request);
    }
}
