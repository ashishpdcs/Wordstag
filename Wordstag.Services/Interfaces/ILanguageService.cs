using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<GetLanguageDto>> GetLanguage(GetLanguageDto request);
        Task<List<GetLanguageDto>> GetAllLanguage();
        Task<List<GetLanguageDto>> GetAllLanguageName();
        Task<Guid> SaveLanguage(SaveLanguageDto request);   
        Task<bool> UpdateLanguage(UpdateLanguageDto request);

        Task<List<GetLanguageJson>> GetAllLanguageDropdown(string? searchKeywords, string? type);
      //  Task<bool> DeleteLanguage(DeleteLanguageDto request);

    }
}
