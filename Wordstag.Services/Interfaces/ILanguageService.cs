using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<GetLanguageDto>> GetLanguage(GetLanguageDto request);
        Task<List<GetLanguageDto>> GetAllLanguage();
        Task<Guid> SaveLanguage(SaveLanguageDto request);   
        Task<bool> UpdateLanguage(UpdateLanguageDto request);
      //  Task<bool> DeleteLanguage(DeleteLanguageDto request);

    }
}
