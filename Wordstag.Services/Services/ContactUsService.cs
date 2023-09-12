using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.ContactUs;
using Wordstag.Domain.Entities.Order;
using Wordstag.Services.Entities.ContactUs;
using Wordstag.Services.Entities.Order;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        public ContactUsService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<Guid> SaveContactUs(SaveContactUsDto request)
        {
       
            var saveContactUs = new ContactUs()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                MobileNo = request.MobileNo,
                Email = request.Email,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.ContactUsRepository.AddAsync(saveContactUs);
            await _readWriteUnitOfWork.CommitAsync();

            return saveContactUs.Id;
        }
    }
}
