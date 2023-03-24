using Wordstag.Services.Entities.UserSample;

namespace Wordstag.Services.Interfaces
{
    public interface IUserSampleService
    {
        Task<List<GetUserSampleDto>> GetUserSample(GetUserSampleDto request);
        Task<List<GetUserSampleDto>> GetAllUserSample();
        Task<Guid> SaveUserSample(SaveUserSampleDto request);   
        Task<bool> UpdateUserSample(UpdateUserSampleDto request);
        Task<bool> DeleteUserSample(DeleteUserSampleDto request);

    }
}
