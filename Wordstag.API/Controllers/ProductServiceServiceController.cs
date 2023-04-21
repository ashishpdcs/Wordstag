using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Wordstag.API.Request.Product;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;
using Wordstag.Services.Services;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductServicesService _productServicesService;
        public ProductServiceServiceController(IProductServicesService productServicesService, IMapper mapper)
        {
            _mapper = mapper;
            _productServicesService = productServicesService;
        }

        [HttpPost("GetAllProductServiceService")]
        public async Task<Dictionary<string, object>> GetAllUserRegister([FromBody] GetProductservicesevice getProductservicesevice)
        {
            var GetProductCertificateDto = _mapper.Map<GetProductservicesevice, ProductServiceDto>(getProductservicesevice);
            var result = await _productServicesService.GetProductServiceService(GetProductCertificateDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("SaveAllProductServiceService")]
        public async Task<Dictionary<string, object>> SaveProductCertificate([FromBody] SaveProductservicesevice  request)
        {
            var saveProductCertificateDto = _mapper.Map<SaveProductservicesevice, SaveProductServiceDto>(request);
            var result = await _productServicesService.SaveProductServiceService(saveProductCertificateDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
