using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface IProductCertificateService
    {
        Task<Guid> SaveProductCertificate(SaveProductCertificateDto request);
        Task<List<GetProductCertificateDto>> GetProductCertificate(GetProductCertificateDto request);
        Task<List<GetProductCertificateDto>> GetAllProductCertificate();
        Task<bool> UpdateProductCertificate(UpdateProductCertificateDto request);
        Task<bool> DeleteProductCertificate(DeleteProductCertificateDto request);
    }
}
