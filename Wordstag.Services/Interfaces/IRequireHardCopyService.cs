using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface IRequireHardCopyService
    {
        Task<int> SaveRequireHardCopy(SaveRequireHardCopyDto request);
        Task<List<GetRequireHardCopyDto>> GetRequireHardCopy(GetRequireHardCopyDto request);
        Task<List<GetRequireHardCopyDto>> GetAllRequireHardCopy();
        Task<bool> UpdateRequireHardCopy(UpdateRequireHardCopyDto request);
        Task<bool> DeleteRequireHardCopy(DeleteRequireHardCopyDto request);
    }
}
