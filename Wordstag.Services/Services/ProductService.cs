using AutoMapper;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        private readonly IFacebookService _facebookService;

        public ProductService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
             IUnitOfWork<MasterDbContext> masterDBContext, IMapper mapper,
             IUnitOfWork<ReadWriteApplicationDbContext> readWriteUnitOfWork,
             ReadWriteApplicationDbContext readWriteUnitOfWorkSP, IFacebookService facebookService)
        {
            _readOnlyUnitOfWork = readOnlyUnitOfWork;
            _masterDBContext = masterDBContext;
            _readWriteUnitOfWork = readWriteUnitOfWork;
            _mapper = mapper;
            _readWriteUnitOfWorkSP = readWriteUnitOfWorkSP;
            _facebookService = facebookService;
        }
        public async Task<List<GetProductDto>> GetProduct(GetProductDto request)
        {
            var data = (from ProductTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                        where ProductTB.Product_Id == request.Product_Id && ProductTB.IsDeleted != true
                        select new GetProductDto
                        {
                            Product_Id = ProductTB.Product_Id,
                            Product_Name = ProductTB.Product_Name,
                            Description = ProductTB.Description,
                            Price = ProductTB.Price,
                            Product_TypeID = ProductTB.Product_TypeID,
                            From_Language = ProductTB.From_Language,
                            To_Language = ProductTB.To_Language,
                            CreatedBy = ProductTB.CreatedBy,
                            CreatedOn = ProductTB.CreatedOn, 
                            UpdatedBy = ProductTB.UpdatedBy,
                            UpdatedOn = ProductTB.UpdatedOn,
                            IsDeleted = ProductTB.IsDeleted,
                        }).ToList();
            return data;
        }
        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var data = (from ProductTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                        where ProductTB.IsDeleted != true
                        select new GetProductDto
                        {
                            Product_Id = ProductTB.Product_Id,
                            Product_Name = ProductTB.Product_Name,
                            Description = ProductTB.Description,
                            Price = ProductTB.Price,
                            Product_TypeID = ProductTB.Product_TypeID,
                            From_Language = ProductTB.From_Language,
                            To_Language = ProductTB.To_Language,
                            CreatedBy = ProductTB.CreatedBy,
                            CreatedOn = ProductTB.CreatedOn,
                            UpdatedBy = ProductTB.UpdatedBy,
                            UpdatedOn = ProductTB.UpdatedOn,
                            IsDeleted = ProductTB.IsDeleted,
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveProduct(SaveProductDto request)
        {
            var saveProduct = new Product()
            {
                Product_Id = Guid.NewGuid(),
                Product_Name = request.Product_Name,
                Description = request.Description,
                Price = request.Price,
                Product_TypeID = request.Product_TypeID,
                From_Language = request.From_Language,
                To_Language = request.To_Language,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.ProductRepository.AddAsync(saveProduct);
            await _readWriteUnitOfWork.CommitAsync();

            return saveProduct.Product_Id;
        }

        public async Task<bool> UpdateProduct(UpdateProductDto request)
        {
            var data = await _readWriteUnitOfWork.ProductRepository.GetFirstOrDefaultAsync(x => x.Product_Id == request.Product_Id);
            if (data != null)
            {
                data.Product_Name = request.Product_Name;
                data.Description = request.Description;
                data.Price = request.Price;
                data.Product_TypeID = request.Product_TypeID;
                data.From_Language = request.From_Language;
                data.To_Language = request.To_Language;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(DeleteProductDto request)
        {
            var data = await _readWriteUnitOfWork.ProductRepository.GetFirstOrDefaultAsync(x => x.Product_Id == request.Product_Id);
            if (data != null)
            {
                data.IsDeleted = true;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

    }
}
