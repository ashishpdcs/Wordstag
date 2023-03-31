using AutoMapper;
using System.Linq;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.Services.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public ProductTypeService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
             IUnitOfWork<MasterDbContext> masterDBContext, IMapper mapper,
             IUnitOfWork<ReadWriteApplicationDbContext> readWriteUnitOfWork,
             ReadWriteApplicationDbContext readWriteUnitOfWorkSP)
        {
            _readOnlyUnitOfWork = readOnlyUnitOfWork;
            _masterDBContext = masterDBContext;
            _readWriteUnitOfWork = readWriteUnitOfWork;
            _mapper = mapper;
            _readWriteUnitOfWorkSP = readWriteUnitOfWorkSP;
        }
        public async Task<List<GetProductTypeDto>> GetProductType(GetProductTypeDto request)
        {
            var data = (from ProductTypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                        where ProductTypeTB.TypeId == request.TypeId  && ProductTypeTB.IsDeleted != true
                        select new GetProductTypeDto
                        {
                            TypeId = ProductTypeTB.TypeId,
                            ProductTypeName = ProductTypeTB.ProductTypeName,
                            ProductTypeDescription = ProductTypeTB.ProductTypeDescription,
                            CreatedBy = ProductTypeTB.CreatedBy,
                            CreatedOn = ProductTypeTB.CreatedOn, 
                            UpdatedBy = ProductTypeTB.UpdatedBy,
                            UpdatedOn = ProductTypeTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<GenericList<GetProductTypeDto>> GetAllProductType(PaginationDto paginationDto)
        {
            var dataQuery = (from ProductTypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                        where ProductTypeTB.IsDeleted != true
                        select new GetProductTypeDto
                        {
                            TypeId = ProductTypeTB.TypeId,
                            ProductTypeName = ProductTypeTB.ProductTypeName,
                            ProductTypeDescription = ProductTypeTB.ProductTypeDescription,
                            CreatedBy = ProductTypeTB.CreatedBy,
                            CreatedOn = ProductTypeTB.CreatedOn,
                            UpdatedBy = ProductTypeTB.UpdatedBy,
                            UpdatedOn = ProductTypeTB.UpdatedOn,
                        });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.ProductTypeName.Contains(paginationDto.GlobalSearch)
                || (x.ProductTypeName != null && x.ProductTypeName.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetProductTypeDto>();
            data.List = paginationDto.PageIndex == 0 ? dataQuery.ToList() : dataQuery.Skip(((paginationDto.PageIndex.Value - 1) * paginationDto.PageSize.Value)).Take(paginationDto.PageSize.Value).ToList();
            data.TotalCount = dataCount;
            data.PageCount = dataCount;
            if (paginationDto.PageSize != null && paginationDto.PageSize != 0)
            {
                if (data.TotalCount % paginationDto.PageSize.Value == 0)
                {
                    data.PageCount = data.TotalCount / paginationDto.PageSize.Value;
                }
                else
                {
                    data.PageCount = (data.TotalCount / paginationDto.PageSize.Value) + 1;
                }
            }
            return data;
        }
        public async Task<Guid> SaveProductType(SaveProductTypeDto request)
        {
            var saveProductType = new ProductType()
            {
                TypeId = Guid.NewGuid(),
                ProductTypeName = request.ProductTypeName,
                ProductTypeDescription = request.ProductTypeDescription,
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
                data.ProductTypeName = request.ProductTypeName;
                data.ProductTypeDescription = request.ProductTypeDescription;
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
