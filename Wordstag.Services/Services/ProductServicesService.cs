using AutoMapper;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class ProductServicesService :IProductServicesService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public ProductServicesService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<ProductServiceDto>> GetProductServiceService(ProductServiceDto productServiceDto)
        {
            var data = (from productServiceServiceTB in _readOnlyUnitOfWork.ProductServiceRepository.GetAllAsQuerable()
                        where productServiceServiceTB.ProductId == productServiceDto.ProductId
                        select new ProductServiceDto
                        {
                            Id = productServiceServiceTB.Id,
                            ProductId = productServiceServiceTB.ProductId,
                            Name = productServiceServiceTB.Name,
                            Description = productServiceServiceTB.Description,
                            Price = productServiceServiceTB.Price,
                            ParentId = productServiceServiceTB.ParentId,
                            TypeOfElement = productServiceServiceTB.TypeOfElement,
                            IsActive = productServiceServiceTB.IsActive,
                            IsDeleted = productServiceServiceTB.IsDeleted,
                            CreatedBy = productServiceServiceTB.CreatedBy,
                            CreatedOn = productServiceServiceTB.CreatedOn,
                            SetDefault = productServiceServiceTB.SetDefault,
                        }).ToList();
            return data;
        }

        public async Task<int> SaveProductServiceService(SaveProductServiceDto request)
        {
            var saveproductCertificate = new ProductServicetbl()
            {
                ProductId = request.ProductId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ParentId = request.ParentId,
                TypeOfElement = request.TypeOfElement,
                IsActive = true,
                IsDeleted = false,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };

            await _readWriteUnitOfWork.ProductServiceRepository.AddAsync(saveproductCertificate);
            await _readWriteUnitOfWork.CommitAsync();

            return saveproductCertificate.Id;
        }
    }
}
