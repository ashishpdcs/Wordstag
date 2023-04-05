using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.Product;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpPost("GetProduct")]
        public async Task<Dictionary<string, object>> GetProduct([FromBody] GetProductRequest request)
        {
            var userdto = _mapper.Map<GetProductRequest, GetProductDto>(request);
            var result = await _productService.GetProduct(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllProduct")]
        public async Task<Dictionary<string, object>> GetAllProduct()
        {
            var result = await _productService.GetAllProduct();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllProductWithPagination")]
        public async Task<Dictionary<string, object>> GetAllProductWithPagination(PaginationDto paginationDto)
        {
            var result = await _productService.GetAllProductWithPagination(paginationDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("SaveProduct")]
        public async Task<Dictionary<string, object>> SaveProduct([FromBody] SaveProductRequest request)
        {
            var saveProductDto = _mapper.Map<SaveProductRequest, SaveProductDto>(request);
            var result = await _productService.SaveProduct(saveProductDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateProduct")]
        public async Task<Dictionary<string, object>> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            var updateProductDto = _mapper.Map<UpdateProductRequest, UpdateProductDto>(request);
            var result = await _productService.UpdateProduct(updateProductDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("DeleteProduct")]
        public async Task<Dictionary<string, object>> DeleteProduct([FromBody] DeleteProductRequest request)
        {
            var deleteProduct = _mapper.Map<DeleteProductRequest, DeleteProductDto>(request);
            var result = await _productService.DeleteProduct(deleteProduct);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
