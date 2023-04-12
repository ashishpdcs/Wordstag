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
    public class NeedApostilleService : INeedApostilleService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public NeedApostilleService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<int> SaveNeedApostille(SaveNeedApostilleDto request)
        {
            var needApostille = new NeedApostille()
            {
                Details = request.Details,
                Amount = request.Amount,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };

            await _readWriteUnitOfWork.needApostilleRepository.AddAsync(needApostille);
            await _readWriteUnitOfWork.CommitAsync();

            return needApostille.Id;
        }

        public async Task<List<GetNeedApostilleDto>> GetNeedApostille(GetNeedApostilleDto request)
        {
            var data = (from NeedApostille NATB in _readOnlyUnitOfWork.needApostilleRepository.GetAllAsQuerable()
                        where (NATB.Id == request.Id && NATB.IsDeleted != true)
                        select new GetNeedApostilleDto
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

        public async Task<List<GetNeedApostilleDto>> GetAllNeedApostille()
        {
            var data = (from NeedApostille NATB in _readOnlyUnitOfWork.needApostilleRepository.GetAllAsQuerable()
                        where (NATB.IsDeleted != true)
                        select new GetNeedApostilleDto
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

        public async Task<bool> UpdateNeedApostille(UpdateNeedApostilleDto request)
        {
            var data = await _readWriteUnitOfWork.needApostilleRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
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

        public async Task<bool> DeleteNeedApostille(DeleteNeedApostilleDto request)
        {
            var data = await _readWriteUnitOfWork.needApostilleRepository.GetFirstOrDefaultAsync(x => x.Id== request.Id);
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
