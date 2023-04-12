using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class NeedApostilleMappingProfile : Profile
    {
        public NeedApostilleMappingProfile()
        {
            CreateMap<SaveNeedApostilleRequest, SaveNeedApostilleDto>();
            CreateMap<NeedApostille, SaveNeedApostilleDto>().ReverseMap();
            CreateMap<GetNeedApostilleRequest, GetNeedApostilleDto>();
            CreateMap<NeedApostille, GetNeedApostilleDto>().ReverseMap();
            CreateMap<UpdateNeedApostilleRequest, UpdateNeedApostilleDto>();
            CreateMap<NeedApostille, UpdateNeedApostilleDto>().ReverseMap();
            CreateMap<DeleteNeedApostilleRequest, DeleteNeedApostilleDto>();
            CreateMap<NeedApostille, DeleteNeedApostilleDto>().ReverseMap();





        }
    }
}

