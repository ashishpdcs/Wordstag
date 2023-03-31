using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService, IMapper mapper)
        {
            _mapper = mapper;
            _productTypeService = productTypeService;
        }
        [HttpPost("GetProductType")]
        public async Task<Dictionary<string, object>> GetProductType([FromBody] GetProductTypeRequest request)
        {
            var userdto = _mapper.Map<GetProductTypeRequest, GetProductTypeDto>(request);
            var result = await _productTypeService.GetProductType(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllProductType")]
        public async Task<Dictionary<string, object>> GetAllProductType(PaginationDto paginationDto)
        {
            var result = await _productTypeService.GetAllProductType(paginationDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveProductType")]
        public async Task<Dictionary<string, object>> SaveProductType([FromBody] SaveProductTypeRequest request)
        {
            var saveProductTypeDto = _mapper.Map<SaveProductTypeRequest, SaveProductTypeDto>(request);
            var result = await _productTypeService.SaveProductType(saveProductTypeDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateProductType")]
        public async Task<Dictionary<string, object>> UpdateProductType([FromBody] UpdateProductTypeRequest request)
        {
            var updateProductTypeDto = _mapper.Map<UpdateProductTypeRequest, UpdateProductTypeDto>(request);
            var result = await _productTypeService.UpdateProductType(updateProductTypeDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("DeleteProductType")]
        public async Task<Dictionary<string, object>> DeleteProductType([FromBody] DeleteProductTypeRequest request)
        {
            var deleteProductType = _mapper.Map<DeleteProductTypeRequest, DeleteProductTypeDto>(request);
            var result = await _productTypeService.DeleteProductType(deleteProductType);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
