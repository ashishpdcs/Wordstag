using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class NotarizedAndCertyIndianAddressService : INotarizedAndCertyIndianAddressService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public NotarizedAndCertyIndianAddressService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<int> SaveNotarizedAndCertyIndianAddress(SaveNotarizedAndCertyIndianAddressDto request)
        {
            var data = new NotarizedAndCertyIndianAddress()
            {
                Details = request.Details,
                Amount = request.Amount,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };

            await _readWriteUnitOfWork.notarizedAndCertyIndianAddressRepository.AddAsync(data);
            await _readWriteUnitOfWork.CommitAsync();

            return data.Id;
        }

        public async Task<List<GetNotarizedAndCertyIndianAddressDto>> GetNotarizedAndCertyIndianAddress(GetNotarizedAndCertyIndianAddressDto request)
        {
            var data = (from NotarizedAndCertyIndianAddress NATB in _readOnlyUnitOfWork.notarizedAndCertyIndianAddressRepository.GetAllAsQuerable()
                        where (NATB.Id == request.Id && NATB.IsDeleted != true)
                        select new GetNotarizedAndCertyIndianAddressDto
                        {
                            Id = NATB.Id,
                            Details = NATB.Details,
                            Amount = NATB.Amount,
                            CreatedBy = NATB.CreatedBy,
                            CreatedOn = NATB.CreatedOn,
                            UpdatedBy = NATB.UpdatedBy,
                            UpdatedOn = NATB.UpdatedOn, 

                        }).ToList();

            return data;
        }

        public async Task<List<GetNotarizedAndCertyIndianAddressDto>> GetAllNotarizedAndCertyIndianAddress()
        {
            var data = (from NotarizedAndCertyIndianAddress NATB in _readOnlyUnitOfWork.notarizedAndCertyIndianAddressRepository.GetAllAsQuerable()
                        where (NATB.IsDeleted != true)
                        select new GetNotarizedAndCertyIndianAddressDto
                        {
                            Id = NATB.Id,
                            Details = NATB.Details,
                            Amount = NATB.Amount,
                            CreatedBy = NATB.CreatedBy,
                            CreatedOn = NATB.CreatedOn,
                            UpdatedBy = NATB.UpdatedBy,
                            UpdatedOn = NATB.UpdatedOn,

                        }).ToList();

            return data;
        }

        public async Task<bool> UpdateNotarizedAndCertyIndianAddress(UpdateNotarizedAndCertyIndianAddressDto request)
        {
            var data = await _readWriteUnitOfWork.notarizedAndCertyIndianAddressRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (data != null)
            {
                data.Details = request.Details;
                data.Amount = request.Amount;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteNotarizedAndCertyIndianAddress(DeleteNotarizedAndCertyIndianAddressDto request)
        {
            var data = await _readWriteUnitOfWork.notarizedAndCertyIndianAddressRepository.GetFirstOrDefaultAsync(x => x.Id== request.Id);
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
