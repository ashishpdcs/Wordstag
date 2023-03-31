using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<GetLanguageDto>> GetLanguage(GetLanguageDto request);
        Task<GenericList<GetLanguageDto>> GetAllLanguage(PaginationDto paginationDto);
        Task<Guid> SaveLanguage(SaveLanguageDto request);   
        Task<bool> UpdateLanguage(UpdateLanguageDto request);
      //  Task<bool> DeleteLanguage(DeleteLanguageDto request);

    }
}
