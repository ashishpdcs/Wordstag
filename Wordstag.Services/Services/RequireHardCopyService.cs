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
    public class RequireHardCopyService : IRequireHardCopyService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public RequireHardCopyService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<int> SaveRequireHardCopy(SaveRequireHardCopyDto request)
        {
            var requiredHardCopy = new RequireHardCopy()
            {
                Details = request.Details,
                Amount = request.Amount,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };

            await _readWriteUnitOfWork.requireHardCopyRepository.AddAsync(requiredHardCopy);
            await _readWriteUnitOfWork.CommitAsync();

            return requiredHardCopy.Id;
        }

        public async Task<List<GetRequireHardCopyDto>> GetRequireHardCopy(GetRequireHardCopyDto request)
        {
            var data = (from RequireHardCopy RCTB in _readOnlyUnitOfWork.requireHardCopyRepository.GetAllAsQuerable()
                        where (RCTB.Id == request.Id && RCTB.IsDeleted != true)
                        select new GetRequireHardCopyDto
                        {
                            Id = RCTB.Id,
                            Details = RCTB.Details,
                            Amount = RCTB.Amount,
                            CreatedBy = RCTB.CreatedBy,
                            CreatedOn = RCTB.CreatedOn,
                            UpdatedBy = RCTB.UpdatedBy,
                            UpdatedOn = RCTB.UpdatedOn,

                        }).ToList();

            return data;
        }

        public async Task<List<GetRequireHardCopyDto>> GetAllRequireHardCopy()
        {
            var data = (from RequireHardCopy RCTB in _readOnlyUnitOfWork.requireHardCopyRepository.GetAllAsQuerable()
                        where (RCTB.IsDeleted != true)
                        select new GetRequireHardCopyDto
                        {
                            Id = RCTB.Id,
                            Details = RCTB.Details,
                            Amount = RCTB.Amount,
                            CreatedBy = RCTB.CreatedBy,
                            CreatedOn = RCTB.CreatedOn,
                            UpdatedBy = RCTB.UpdatedBy,
                            UpdatedOn = RCTB.UpdatedOn,

                        }).ToList();

            return data;
        }

        public async Task<bool> UpdateRequireHardCopy(UpdateRequireHardCopyDto request)
        {
            var data = await _readWriteUnitOfWork.requireHardCopyRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
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

        public async Task<bool> DeleteRequireHardCopy(DeleteRequireHardCopyDto request)
        {
            var data = await _readWriteUnitOfWork.requireHardCopyRepository.GetFirstOrDefaultAsync(x => x.Id== request.Id);
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
