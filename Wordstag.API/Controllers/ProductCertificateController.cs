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
    public class ProductCertificateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductCertificateService _productCertificateService;
        public ProductCertificateController(IProductCertificateService productCertificateService, IMapper mapper)
        {
            _mapper = mapper;
            _productCertificateService = productCertificateService;
        }
       
        [HttpPost("SaveProductCertificate")]
        public async Task<Dictionary<string, object>> SaveProductCertificate([FromBody] SaveProductCertificateRequest request)
        {
            var saveProductCertificateDto = _mapper.Map<SaveProductCertificateRequest, SaveProductCertificateDto>(request);
            var result = await _productCertificateService.SaveProductCertificate(saveProductCertificateDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetProductCertificate")]
        public async Task<Dictionary<string, object>> GetProductCertificate([FromBody] GetProductCertificateRequest request)
        {
            var productCertificateDto = _mapper.Map<GetProductCertificateRequest, GetProductCertificateDto>(request);
            var result = await _productCertificateService.GetProductCertificate(productCertificateDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
       
        [HttpPost("GetAllProductCertificate")]
        public async Task<Dictionary<string, object>> GetAllProductCertificate()
        {
            var result = await _productCertificateService.GetAllProductCertificate();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("UpdateProductCertificate")]
        public async Task<Dictionary<string, object>> UpdateProductCertificate([FromBody] UpdateProductCertificateRequest request)
        {
            var updateProductCertificateDto = _mapper.Map<UpdateProductCertificateRequest, UpdateProductCertificateDto>(request);
            var result = await _productCertificateService.UpdateProductCertificate(updateProductCertificateDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("DeleteProductCertificate")]
        public async Task<Dictionary<string, object>> DeleteProductCertificate([FromBody] DeleteProductCertificateRequest request)
        {
            var DeleteProductCertificateDto = _mapper.Map<DeleteProductCertificateRequest, DeleteProductCertificateDto>(request);
            var result = await _productCertificateService.DeleteProductCertificate(DeleteProductCertificateDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }



    }
}
