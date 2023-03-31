using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Interfaces
{
    public interface IUserRegisterService
    {
        Task<UserRegisterDto> UserRegisterAsync(UserRegisterDto request, string ipAddress);
        Task<List<GetUserRegisterDto>> GetUserRegister(GetUserRegisterDto request);
        Task<GenericList<GetUserRegisterDto>> GetAllUserRegister(PaginationDto paginationDto);
        Task<Guid> SaveUserRegister(SaveUserRegisterDto request);   
        Task<bool> UpdateUserRegister(UpdateUserRegisterDto request);
        Task<bool> DeleteUserRegister(DeleteUserRegisterDto request);

    }
}
