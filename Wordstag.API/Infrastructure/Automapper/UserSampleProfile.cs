using AutoMapper;
using Wordstag.API.Request.UserSample;
using Wordstag.Domain.Entities.UserSample;
using Wordstag.Services.Entities.UserSample;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class UserSampleMappingProfile : Profile
    {
        public  UserSampleMappingProfile()
        {
            CreateMap<GetUserSampleRequest, GetUserSampleDto>();
            CreateMap<UserSample, GetUserSampleDto>().ReverseMap();

            CreateMap<SaveUserSampleRequest, SaveUserSampleDto>();
            CreateMap<UserSample, SaveUserSampleDto>().ReverseMap();

            CreateMap<UpdateUserSampleRequest, UpdateUserSampleDto>();
            CreateMap<UserSample, UpdateUserSampleDto>().ReverseMap();

            CreateMap<DeleteUserSampleRequest, DeleteUserSampleDto>();
            CreateMap<UserSample, DeleteUserSampleDto>().ReverseMap();
        }
    }
}

