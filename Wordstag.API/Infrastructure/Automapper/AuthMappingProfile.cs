using AutoMapper;
using Wordstag.API.Requests.User;
using Wordstag.Services.Entities.User;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<UserAuthRequest, UserAuthRequestDto>();
        }
    }
}
