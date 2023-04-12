using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface INeedApostilleService
    {
        Task<int> SaveNeedApostille(SaveNeedApostilleDto request);
        Task<List<GetNeedApostilleDto>> GetNeedApostille(GetNeedApostilleDto request);
        Task<List<GetNeedApostilleDto>> GetAllNeedApostille();
        Task<bool> UpdateNeedApostille(UpdateNeedApostilleDto request);
        Task<bool> DeleteNeedApostille(DeleteNeedApostilleDto request);

    }
}
