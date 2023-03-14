using Wordstag.Services.Entities.Master;
using Wordstag.Services.Entities;

namespace Wordstag.Services.Interfaces
{
    public interface IMasterService
    {
      
        Task<List<CountryMasterDto>> GetCountry();
        Task<List<StateMasterDto>> GetState(StateMasterDto request);
        Task<List<CityMasterDto>> GetCity(CityMasterDto request);

    }
}