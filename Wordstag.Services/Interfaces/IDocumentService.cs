using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<List<GetDocumentDto>> GetDocument(GetDocumentDto request);
        Task<GenericList<GetDocumentDto>> GetAllDocument(PaginationDto paginationDto);
        Task<Guid> SaveDocument(SaveDocumentDto request);   
        Task<bool> UpdateDocument(UpdateDocumentDto request);
        //Task<bool> DeleteDocument(DeleteDocumentDto request);

    }
}
