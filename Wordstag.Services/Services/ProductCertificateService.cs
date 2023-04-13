using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class ProductCertificateService : IProductCertificateService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public ProductCertificateService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<Guid> SaveProductCertificate(SaveProductCertificateDto request)
        {
            var saveproductCertificate = new ProductCertificate()
            {
                ProductCertificateId = Guid.NewGuid(),
                ProductId = request.ProductId,
                Noofapplicants = request.Noofapplicants,
                Requiredservices = request.Requiredservices,
                DocumentsApostilled = request.DocumentsApostilled,
                CanadaImmigrationVisa = request.CanadaImmigrationVisa,
                NotarizedAndCertyIndianAddressId = request.NotarizedAndCertyIndianAddressId,
                NotarizedTranslation = request.NotarizedTranslation,
                RequireHardCopyId = request.RequireHardCopyId,
                CourierServiceAddress = request.CourierServiceAddress,
                NeedApostilleId = request.NeedApostilleId,
                CourierEntireIndianAddress = request.CourierEntireIndianAddress,
                AvailingApostilleService = request.AvailingApostilleService,
                TotalAmount = request.TotalAmount,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };

            await _readWriteUnitOfWork.productCertificateRepository.AddAsync(saveproductCertificate);
            await _readWriteUnitOfWork.CommitAsync();

            return saveproductCertificate.ProductCertificateId;
        }

        public async Task<List<GetProductCertificateDto>> GetProductCertificate(GetProductCertificateDto request)
        {
            var data = (from ProductCertificate PCTB in _readOnlyUnitOfWork.productCertificateRepository.GetAllAsQuerable()
                        join NotarizedAndCertyIndianAddress NCTB in _readOnlyUnitOfWork.notarizedAndCertyIndianAddressRepository.GetAllAsQuerable()
                        on PCTB.NotarizedAndCertyIndianAddressId equals NCTB.Id
                        join NeedApostille NATB in _readOnlyUnitOfWork.needApostilleRepository.GetAllAsQuerable()
                        on PCTB.NeedApostilleId equals NATB.Id
                        join RequireHardCopy RCTB in _readOnlyUnitOfWork.requireHardCopyRepository.GetAllAsQuerable()
                        on PCTB.RequireHardCopyId equals RCTB.Id
                        where PCTB.ProductCertificateId == request.ProductCertificateId && PCTB.IsDeleted != true
                        select new GetProductCertificateDto
                        {
                            ProductCertificateId = PCTB.ProductCertificateId,
                            ProductId = PCTB.ProductId,
                            Noofapplicants = PCTB.Noofapplicants,
                            Requiredservices = PCTB.Requiredservices,
                            DocumentsApostilled = PCTB.DocumentsApostilled,
                            CanadaImmigrationVisa = PCTB.CanadaImmigrationVisa,
                            NotarizedAndCertyIndianAddressId = PCTB.NotarizedAndCertyIndianAddressId,
                            NotarizedTranslation = PCTB.NotarizedTranslation,
                            RequireHardCopyId = PCTB.RequireHardCopyId,
                            CourierServiceAddress = PCTB.CourierServiceAddress,
                            NeedApostilleId = PCTB.NeedApostilleId,
                            CourierEntireIndianAddress = PCTB.CourierEntireIndianAddress,
                            AvailingApostilleService = PCTB.AvailingApostilleService,
                            TotalAmount = PCTB.TotalAmount,
                            CreatedOn = PCTB.CreatedOn,
                            CreatedBy = PCTB.CreatedBy,
                            productDetails = (from Product ProTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                                              where (PCTB.ProductId == ProTB.ProductId && ProTB.IsDeleted != true)
                                              select new GetProductDto
                                              {
                                                  ProductId = ProTB.ProductId,
                                                  ProductName = ProTB.ProductName,
                                                  Description = ProTB.Description,
                                                  Price = ProTB.Price,
                                                  ProductTypeId = ProTB.ProductTypeId,
                                                  FromLanguage = ProTB.FromLanguage,
                                                  ToLanguage = ProTB.ToLanguage,
                                                  PlanId = ProTB.PlanId,
                                              }).ToList(),
                            requiredHardCopyDetails = (from RequireHardCopy RCTB in _readOnlyUnitOfWork.requireHardCopyRepository.GetAllAsQuerable()
                                                       where (PCTB.RequireHardCopyId == RCTB.Id && RCTB.IsDeleted != true)
                                                       select new GetRequireHardCopyDto
                                                       {
                                                           Id = RCTB.Id,
                                                           Details = RCTB.Details,
                                                           Amount = RCTB.Amount,
                                                       }).ToList(),
                            needApostilleDetails = (from NeedApostille NATB in _readOnlyUnitOfWork.needApostilleRepository.GetAllAsQuerable()
                                                    where (PCTB.NeedApostilleId == NATB.Id && NATB.IsDeleted != true)
                                                    select new GetNeedApostilleDto
                                                    {
                                                        Id = NATB.Id,
                                                        Details = NATB.Details,
                                                        Amount = NATB.Amount,
                                                    }).ToList(),
                            notraizedCertyAddressDetails = (from NotarizedAndCertyIndianAddress NCTB in _readOnlyUnitOfWork.notarizedAndCertyIndianAddressRepository.GetAllAsQuerable()
                                                            where (PCTB.NotarizedAndCertyIndianAddressId == NCTB.Id && NCTB.IsDeleted != true)
                                                            select new GetNotarizedAndCertyIndianAddressDto
                                                            {
                                                                Id = NCTB.Id,
                                                                Details = NCTB.Details,
                                                                Amount = NCTB.Amount,
                                                            }).ToList(),
                        }).ToList();



            return data;
        }

        public async Task<List<GetProductCertificateDto>> GetAllProductCertificate()
        {
            var data = (from ProductCertificate PCTB in _readOnlyUnitOfWork.productCertificateRepository.GetAllAsQuerable()
                        join NotarizedAndCertyIndianAddress NCTB in _readOnlyUnitOfWork.notarizedAndCertyIndianAddressRepository.GetAllAsQuerable()
                        on PCTB.NotarizedAndCertyIndianAddressId equals NCTB.Id
                        join NeedApostille NATB in _readOnlyUnitOfWork.needApostilleRepository.GetAllAsQuerable()
                        on PCTB.NeedApostilleId equals NATB.Id
                        join RequireHardCopy RCTB in _readOnlyUnitOfWork.requireHardCopyRepository.GetAllAsQuerable()
                        on PCTB.RequireHardCopyId equals RCTB.Id
                        where PCTB.IsDeleted != true
                        select new GetProductCertificateDto
                        {
                            ProductCertificateId = PCTB.ProductCertificateId,
                            ProductId = PCTB.ProductId,
                            Noofapplicants = PCTB.Noofapplicants,
                            Requiredservices = PCTB.Requiredservices,
                            DocumentsApostilled = PCTB.DocumentsApostilled,
                            CanadaImmigrationVisa = PCTB.CanadaImmigrationVisa,
                            NotarizedAndCertyIndianAddressId = PCTB.NotarizedAndCertyIndianAddressId,
                            NotarizedTranslation = PCTB.NotarizedTranslation,
                            RequireHardCopyId = PCTB.RequireHardCopyId,
                            CourierServiceAddress = PCTB.CourierServiceAddress,
                            NeedApostilleId = PCTB.NeedApostilleId,
                            CourierEntireIndianAddress = PCTB.CourierEntireIndianAddress,
                            AvailingApostilleService = PCTB.AvailingApostilleService,
                            TotalAmount = PCTB.TotalAmount,
                            CreatedOn = PCTB.CreatedOn,
                            CreatedBy = PCTB.CreatedBy,

                            productDetails = (from Product ProTB in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                                              where (PCTB.ProductId == ProTB.ProductId && ProTB.IsDeleted != true)
                                              select new GetProductDto
                                              {
                                                  ProductId = ProTB.ProductId,
                                                  ProductName = ProTB.ProductName,
                                                  Description = ProTB.Description,
                                                  Price = ProTB.Price,
                                                  ProductTypeId = ProTB.ProductTypeId,
                                                  FromLanguage = ProTB.FromLanguage,
                                                  ToLanguage = ProTB.ToLanguage,
                                                  PlanId = ProTB.PlanId,
                                              }).ToList(),
                            requiredHardCopyDetails = (from RequireHardCopy RCTB in _readOnlyUnitOfWork.requireHardCopyRepository.GetAllAsQuerable()
                                                       where (PCTB.RequireHardCopyId == RCTB.Id && RCTB.IsDeleted != true)
                                                       select new GetRequireHardCopyDto
                                                       {
                                                           Id = RCTB.Id,
                                                           Details = RCTB.Details,
                                                           Amount = RCTB.Amount,
                                                       }).ToList(),
                            needApostilleDetails = (from NeedApostille NATB in _readOnlyUnitOfWork.needApostilleRepository.GetAllAsQuerable()
                                                    where (PCTB.NeedApostilleId == NATB.Id && NATB.IsDeleted != true)
                                                    select new GetNeedApostilleDto
                                                    {
                                                        Id = NATB.Id,
                                                        Details = NATB.Details,
                                                        Amount = NATB.Amount,
                                                    }).ToList(),
                            notraizedCertyAddressDetails = (from NotarizedAndCertyIndianAddress NCTB in _readOnlyUnitOfWork.notarizedAndCertyIndianAddressRepository.GetAllAsQuerable()
                                                            where (PCTB.NotarizedAndCertyIndianAddressId == NCTB.Id && NCTB.IsDeleted != true)
                                                            select new GetNotarizedAndCertyIndianAddressDto
                                                            {
                                                                Id = NCTB.Id,
                                                                Details = NCTB.Details,
                                                                Amount = NCTB.Amount,
                                                            }).ToList(),

                        }).ToList();

            return data;
        }

        public async Task<bool> UpdateProductCertificate(UpdateProductCertificateDto request)
        {
            var data = await _readWriteUnitOfWork.productCertificateRepository.GetFirstOrDefaultAsync(x => x.ProductCertificateId == request.ProductCertificateId);
            if (data != null)
            {
                data.ProductId = request.ProductId;
                data.Noofapplicants = request.Noofapplicants;
                data.Requiredservices = request.Requiredservices;
                data.DocumentsApostilled = request.DocumentsApostilled;
                data.CanadaImmigrationVisa = request.CanadaImmigrationVisa;
                data.NotarizedAndCertyIndianAddressId = request.NotarizedAndCertyIndianAddressId;
                data.NotarizedTranslation = request.NotarizedTranslation;
                data.RequireHardCopyId = request.RequireHardCopyId;
                data.CourierServiceAddress = request.CourierServiceAddress;
                data.NeedApostilleId = request.NeedApostilleId;
                data.CourierEntireIndianAddress = request.CourierEntireIndianAddress;
                data.AvailingApostilleService = request.AvailingApostilleService;
                data.TotalAmount = request.TotalAmount;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductCertificate(DeleteProductCertificateDto request)
        {
            var data = await _readWriteUnitOfWork.productCertificateRepository.GetFirstOrDefaultAsync(x => x.ProductCertificateId == request.ProductCertificateId);
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
