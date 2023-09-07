using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Vendor;

namespace Wordstag.Services.Interfaces
{
    public interface IVendorRegisterService
    {
        Task<Guid> SaveVendorRegister(SaveVendorDto request);
        Task<bool> UpdateVendorRegister(UpdateVendorDto request);
        Task<bool> DeleteVendorRegister(DeleteVendorDto request);
        Task<List<GetVendorSkill>> GetAllVendorSkill();
        Task<List<GetVendorSkill>> GetVendorSkill(Guid VendorSkillId);

	}
}
