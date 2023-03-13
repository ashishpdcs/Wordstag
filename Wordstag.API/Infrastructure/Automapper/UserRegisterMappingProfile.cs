using AutoMapper;
using Wordstag.API.Request.User;
using Wordstag.API.Requests.User;
using Wordstag.Domain.Entities.User;
using Wordstag.Services.Entities.User;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class UserRegisterMappingProfile : Profile
    {
        public  UserRegisterMappingProfile()
        {
            CreateMap<GetUserRegisterRequest, GetUserRegisterDto>();
            CreateMap<UserRegister, GetUserRegisterDto>().ReverseMap();

            CreateMap<SaveUserRegisterRequest, SaveUserRegisterDto>();
            CreateMap<UserRegister, SaveUserRegisterDto>().ReverseMap();

            CreateMap<UpdateUserRegisterRequest, UpdateUserRegisterDto>();
            CreateMap<UserRegister, UpdateUserRegisterDto>().ReverseMap();

            CreateMap<DeleteUserRegisterRequest, DeleteUserRegisterDto>();
            CreateMap<UserRegister, DeleteUserRegisterDto>().ReverseMap();
        }
    }
}

