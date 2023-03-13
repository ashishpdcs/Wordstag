using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Interfaces
{
    public interface IUserRegisterService
    {
        Task<UserRegisterDto> UserRegisterAsync(UserRegisterDto request, string ipAddress);
        Task<List<GetUserRegisterDto>> GetUserRegister(GetUserRegisterDto request);
        Task<List<GetUserRegisterDto>> GetAllUserRegister();
        Task<Guid> SaveUserRegister(SaveUserRegisterDto request);   
        Task<bool> UpdateUserRegister(UpdateUserRegisterDto request);
        //Task<bool> DeleteUserRegister(DeleteUserRegisterDto request);

    }
}
