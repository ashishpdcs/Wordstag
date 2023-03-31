using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Master;
using Wordstag.Services.Entities.UserSample;

namespace Wordstag.Services.Interfaces
{
    public interface IUserSampleService
    {
        Task<List<GetUserSampleDto>> GetUserSample(GetUserSampleDto request);
        Task<GenericList<GetUserSampleDto>> GetAllUserSample(PaginationDto paginationDto);
        Task<Guid> SaveUserSample(SaveUserSampleDto request);   
        Task<bool> UpdateUserSample(UpdateUserSampleDto request);
        Task<bool> DeleteUserSample(DeleteUserSampleDto request);
        Task<bool> SetApprove(ApproveAndUnApproveDto request);
        Task<List<GetUserSampleDto>> SearchApprove(GetUserSampleDto request);
    }
}
