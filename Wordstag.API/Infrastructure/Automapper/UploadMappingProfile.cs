using AutoMapper;
using Wordstag.API.Request.Upload;
using Wordstag.Domain.Entities.Upload;
using Wordstag.Services.Entities.Upload;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class UploadMappingProfile : Profile
    {
        public  UploadMappingProfile()
        {
            CreateMap<GetUploadRequest, GetUploadDto>();
            CreateMap<UploadTbl, GetUploadDto>().ReverseMap();

            CreateMap<SaveUploadRequest, SaveUploadDto>();
            CreateMap<UploadTbl, SaveUploadDto>().ReverseMap();

            CreateMap<UpdateUploadRequest, UpdateUploadDto>();
            CreateMap<UploadTbl, UpdateUploadDto>().ReverseMap();

            CreateMap<DeleteUploadRequest, DeleteUploadDto>();
            CreateMap<UploadTbl, DeleteUploadDto>().ReverseMap();
        }
    }
}

