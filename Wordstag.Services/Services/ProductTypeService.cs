using AutoMapper;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        private readonly IFacebookService _facebookService;

        public ProductTypeService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetProductTypeDto>> GetProductType(GetProductTypeDto request)
        {
            var data = (from ProductTypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                        where ProductTypeTB.TypeId == request.TypeId  && ProductTypeTB.IsDeleted != true
                        select new GetProductTypeDto
                        {
                            TypeId = ProductTypeTB.TypeId,
                            ProductType_Name = ProductTypeTB.ProductType_Name,
                            ProductType_Description = ProductTypeTB.ProductType_Description,
                            CreatedBy = ProductTypeTB.CreatedBy,
                            CreatedOn = ProductTypeTB.CreatedOn, 
                            UpdatedBy = ProductTypeTB.UpdatedBy,
                            UpdatedOn = ProductTypeTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<List<GetProductTypeDto>> GetAllProductType()
        {
            var data = (from ProductTypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                        where ProductTypeTB.IsDeleted != true
                        select new GetProductTypeDto
                        {
                            TypeId = ProductTypeTB.TypeId,
                            ProductType_Name = ProductTypeTB.ProductType_Name,
                            ProductType_Description = ProductTypeTB.ProductType_Description,
                            CreatedBy = ProductTypeTB.CreatedBy,
                            CreatedOn = ProductTypeTB.CreatedOn,
                            UpdatedBy = ProductTypeTB.UpdatedBy,
                            UpdatedOn = ProductTypeTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveProductType(SaveProductTypeDto request)
        {
            var saveProductType = new ProductType()
            {
                TypeId = Guid.NewGuid(),
                ProductType_Name = request.ProductType_Name,
                ProductType_Description = request.ProductType_Description,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.ProductTypeRepository.AddAsync(saveProductType);
            await _readWriteUnitOfWork.CommitAsync();

            return saveProductType.TypeId;
        }

        public async Task<bool> UpdateProductType(UpdateProductTypeDto request)
        {
            var data = await _readWriteUnitOfWork.ProductTypeRepository.GetFirstOrDefaultAsync(x => x.TypeId == request.TypeId);
            if (data != null)
            {
                data.ProductType_Name = request.ProductType_Name;
                data.ProductType_Description = request.ProductType_Description;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductType(DeleteProductTypeDto request)
        {
            var data = await _readWriteUnitOfWork.ProductTypeRepository.GetFirstOrDefaultAsync(x => x.TypeId == request.TypeId);
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
