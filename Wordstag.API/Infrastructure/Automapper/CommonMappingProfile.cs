using AutoMapper;
using Wordstag.Services.Entities.Common;
using Wordstag.API.Requests.Common;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<PaginationRequest, PaginationDto>();
        }
    }
}

