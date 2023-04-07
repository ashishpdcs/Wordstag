using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SixLabors.Fonts.Tables.AdvancedTypographic;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetProductDto>> GetProduct(GetProductDto request)
        {
            var data = (from ProductTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                        where ProductTB.ProductId == request.ProductId && ProductTB.IsDeleted != true
                        select new GetProductDto
                        {
                            ProductId = ProductTB.ProductId,
                            ProductName = ProductTB.ProductName,
                            Description = ProductTB.Description,
                            Price = ProductTB.Price,
                            ProductTypeId = ProductTB.ProductTypeId,
                            FromLanguage = ProductTB.FromLanguage,
                            ToLanguage = ProductTB.ToLanguage,
                            CreatedBy = ProductTB.CreatedBy,
                            CreatedOn = ProductTB.CreatedOn,
                            UpdatedBy = ProductTB.UpdatedBy,
                            UpdatedOn = ProductTB.UpdatedOn,
                            IsDeleted = ProductTB.IsDeleted,
                            PlanId = ProductTB.PlanId,
                            Tolanguages = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                           where LanguageTB.LanguageId == ProductTB.ToLanguage
                                           select new GetLanguageDto
                                           {
                                               LanguageId = LanguageTB.LanguageId,
                                               LanguageName = LanguageTB.LanguageName,
                                           }).ToList(),
                            Fromlanguages = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                           where LanguageTB.LanguageId == ProductTB.FromLanguage
                                           select new GetLanguageDto
                                           {
                                               LanguageId = LanguageTB.LanguageId,
                                               LanguageName = LanguageTB.LanguageName,
                                           }).ToList(),
                            planTypes = (from PlantypeTB in _readOnlyUnitOfWork.PlanRepository.GetAllAsQuerable()
                                         where PlantypeTB.Id == ProductTB.PlanId
                                         select new GetPlanDto
                                         {
                                             Id = PlantypeTB.Id,
                                             PlanType = PlantypeTB.PlanType,
                                         }).ToList(),
                            productTypes = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                            where ProducttypeTB.TypeId == ProductTB.ProductTypeId && ProducttypeTB.IsDeleted != true
                                            select new GetProductTypeDto
                                            {
                                                TypeId = ProducttypeTB.TypeId,
                                                ProductTypeName = ProducttypeTB.ProductTypeName,
                                                ProductTypeDescription = ProducttypeTB.ProductTypeDescription,
                                                CreatedBy = ProducttypeTB.CreatedBy,
                                                CreatedOn = ProducttypeTB.CreatedOn,
                                                UpdatedBy = ProducttypeTB.UpdatedBy,
                                                UpdatedOn = ProducttypeTB.UpdatedOn,
                                            }).ToList(),
                        }).ToList();
            return data;
        }
        public async Task<List<GetProductDto>> GetAllProduct(GetProductDto request)
        {
            var data = (from ProductTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                        where ProductTB.IsDeleted != true && ProductTB.ProductTypeId == request.ProductTypeId && ProductTB.FromLanguage == request.FromLanguage && ProductTB.ToLanguage == request.ToLanguage
                        select new GetProductDto
                        {
                            ProductId = ProductTB.ProductId,
                            ProductName = ProductTB.ProductName,
                            Description = ProductTB.Description,
                            Price = ProductTB.Price,
                            ProductTypeId = ProductTB.ProductTypeId,
                            FromLanguage = ProductTB.FromLanguage,
                            ToLanguage = ProductTB.ToLanguage,
                            CreatedBy = ProductTB.CreatedBy,
                            CreatedOn = ProductTB.CreatedOn,
                            UpdatedBy = ProductTB.UpdatedBy,
                            UpdatedOn = ProductTB.UpdatedOn,
                            IsDeleted = ProductTB.IsDeleted,
                            PlanId = ProductTB.PlanId,
                            planTypes = (from PlantypeTB in _readOnlyUnitOfWork.PlanRepository.GetAllAsQuerable()
                                         where PlantypeTB.Id == ProductTB.PlanId
                                         select new GetPlanDto
                                         {
                                             Id = PlantypeTB.Id,
                                             PlanType = PlantypeTB.PlanType,
                                         }).ToList(),
                            Tolanguages = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                           where LanguageTB.LanguageId == ProductTB.ToLanguage
                                           select new GetLanguageDto
                                           {
                                               LanguageId = LanguageTB.LanguageId,
                                               LanguageName = LanguageTB.LanguageName,
                                           }).ToList(),
                            Fromlanguages = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                             where LanguageTB.LanguageId == ProductTB.FromLanguage
                                             select new GetLanguageDto
                                             {
                                                 LanguageId = LanguageTB.LanguageId,
                                                 LanguageName = LanguageTB.LanguageName,
                                             }).ToList(),
                            productTypes = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                            where ProducttypeTB.TypeId == ProductTB.ProductTypeId && ProducttypeTB.IsDeleted != true
                                            select new GetProductTypeDto
                                            {
                                                TypeId = ProducttypeTB.TypeId,
                                                ProductTypeName = ProducttypeTB.ProductTypeName,
                                                ProductTypeDescription = ProducttypeTB.ProductTypeDescription,
                                                CreatedBy = ProducttypeTB.CreatedBy,
                                                CreatedOn = ProducttypeTB.CreatedOn,
                                                UpdatedBy = ProducttypeTB.UpdatedBy,
                                                UpdatedOn = ProducttypeTB.UpdatedOn,
                                            }).ToList(),
                        }).ToList();

            return data;
        }
        public async Task<GenericList<GetProductDto>> GetAllProductWithPagination(PaginationDto paginationDto)
        {
            var dataQuery = (from ProductTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                             where ProductTB.IsDeleted != true
                             select new GetProductDto
                             {
                                 ProductId = ProductTB.ProductId,
                                 ProductName = ProductTB.ProductName,
                                 Description = ProductTB.Description,
                                 Price = ProductTB.Price,
                                 ProductTypeId = ProductTB.ProductTypeId,
                                 FromLanguage = ProductTB.FromLanguage,
                                 ToLanguage = ProductTB.ToLanguage,
                                 CreatedBy = ProductTB.CreatedBy,
                                 CreatedOn = ProductTB.CreatedOn,
                                 UpdatedBy = ProductTB.UpdatedBy,
                                 UpdatedOn = ProductTB.UpdatedOn,
                                 IsDeleted = ProductTB.IsDeleted,
                                 PlanId = ProductTB.PlanId,
                                 planTypes = (from PlantypeTB in _readOnlyUnitOfWork.PlanRepository.GetAllAsQuerable()
                                              where PlantypeTB.Id == ProductTB.PlanId
                                              select new GetPlanDto
                                              {
                                                  Id = PlantypeTB.Id,
                                                  PlanType = PlantypeTB.PlanType,
                                              }).ToList(),
                                 productTypes = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                                 where ProducttypeTB.TypeId == ProductTB.ProductTypeId && ProducttypeTB.IsDeleted != true
                                                 select new GetProductTypeDto
                                                 {
                                                     TypeId = ProducttypeTB.TypeId,
                                                     ProductTypeName = ProducttypeTB.ProductTypeName,
                                                     ProductTypeDescription = ProducttypeTB.ProductTypeDescription,
                                                     CreatedBy = ProducttypeTB.CreatedBy,
                                                     CreatedOn = ProducttypeTB.CreatedOn,
                                                     UpdatedBy = ProducttypeTB.UpdatedBy,
                                                     UpdatedOn = ProducttypeTB.UpdatedOn,
                                                 }).ToList(),
                             });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.ProductName.Contains(paginationDto.GlobalSearch)
                || (x.ProductName != null && x.ProductName.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetProductDto>();
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
        public async Task<Guid> SaveProduct(SaveProductDto request)
        {
            var saveProduct = new Product()
            {
                ProductId = Guid.NewGuid(),
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                ProductTypeId = request.ProductTypeId,
                FromLanguage = request.FromLanguage,
                ToLanguage = request.ToLanguage,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                PlanId = request.PlanId,
            };
            await _readWriteUnitOfWork.ProductRepository.AddAsync(saveProduct);
            await _readWriteUnitOfWork.CommitAsync();

            return saveProduct.ProductId;
        }

        public async Task<bool> UpdateProduct(UpdateProductDto request)
        {
            var data = await _readWriteUnitOfWork.ProductRepository.GetFirstOrDefaultAsync(x => x.ProductId == request.ProductId);
            if (data != null)
            {
                data.ProductName = request.ProductName;
                data.Description = request.Description;
                data.Price = request.Price;
                data.ProductTypeId = request.ProductTypeId;
                data.FromLanguage = request.FromLanguage;
                data.ToLanguage = request.ToLanguage;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(DeleteProductDto request)
        {
            var data = await _readWriteUnitOfWork.ProductRepository.GetFirstOrDefaultAsync(x => x.ProductId == request.ProductId);
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
