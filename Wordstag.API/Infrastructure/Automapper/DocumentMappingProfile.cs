using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class DocumentMappingProfile : Profile
    {
        public  DocumentMappingProfile()
        {
            CreateMap<GetDocumentRequest, GetDocumentDto>();
            CreateMap<Document, GetDocumentDto>().ReverseMap();

            CreateMap<SaveDocumentRequest, SaveDocumentDto>();
            CreateMap<Document, SaveDocumentDto>().ReverseMap();

            CreateMap<UpdateDocumentRequest, UpdateDocumentDto>();
            CreateMap<Document, UpdateDocumentDto>().ReverseMap();

            CreateMap<DeleteDocumentRequest, DeleteDocumentDto>();
            CreateMap<Document, DeleteDocumentDto>().ReverseMap();
        }
    }
}

