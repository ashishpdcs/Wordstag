using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface INotarizedAndCertyIndianAddressService
    {
        Task<int> SaveNotarizedAndCertyIndianAddress(SaveNotarizedAndCertyIndianAddressDto request);
        Task<List<GetNotarizedAndCertyIndianAddressDto>> GetNotarizedAndCertyIndianAddress(GetNotarizedAndCertyIndianAddressDto request);
        Task<List<GetNotarizedAndCertyIndianAddressDto>> GetAllNotarizedAndCertyIndianAddress();
        Task<bool> UpdateNotarizedAndCertyIndianAddress(UpdateNotarizedAndCertyIndianAddressDto request);
        Task<bool> DeleteNotarizedAndCertyIndianAddress(DeleteNotarizedAndCertyIndianAddressDto request);

    }
}
