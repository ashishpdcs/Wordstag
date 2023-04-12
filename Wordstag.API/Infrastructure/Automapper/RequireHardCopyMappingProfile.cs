using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class RequireHardCopyMappingProfile : Profile
    {
        public RequireHardCopyMappingProfile()
        {
            CreateMap<SaveRequireHardCopyRequest, SaveRequireHardCopyDto>();
            CreateMap<RequireHardCopy, SaveRequireHardCopyDto >().ReverseMap();
            CreateMap<GetRequireHardCopyRequest, GetRequireHardCopyDto>();
            CreateMap<RequireHardCopy, GetRequireHardCopyDto>().ReverseMap();
            CreateMap<UpdateRequireHardCopyRequest, UpdateRequireHardCopyDto>();
            CreateMap<RequireHardCopy, UpdateRequireHardCopyDto>().ReverseMap();
            CreateMap<DeleteRequireHardCopyRequest, DeleteRequireHardCopyDto>();
            CreateMap<RequireHardCopy, DeleteRequireHardCopyDto>().ReverseMap();





        }
    }
}

