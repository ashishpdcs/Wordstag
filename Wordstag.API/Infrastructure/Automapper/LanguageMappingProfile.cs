using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class LanguageMappingProfile : Profile
    {
        public  LanguageMappingProfile()
        {
            CreateMap<GetLanguageRequest, GetLanguageDto>();
            CreateMap<Language, GetLanguageDto>().ReverseMap();

            CreateMap<SaveLanguageRequest, SaveLanguageDto>();
            CreateMap<Language, SaveLanguageDto>().ReverseMap();

            CreateMap<UpdateLanguageRequest, UpdateLanguageDto>();
            CreateMap<Language, UpdateLanguageDto>().ReverseMap();

            CreateMap<DeleteLanguageRequest, DeleteLanguageDto>();
            CreateMap<Language, DeleteLanguageDto>().ReverseMap();
        }
    }
}

