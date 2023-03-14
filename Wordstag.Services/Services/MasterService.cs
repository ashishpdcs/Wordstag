using AutoMapper;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Services.Entities.Master;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class MasterService : IMasterService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        public MasterService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<CountryMasterDto>> GetCountry()
        {
            var data = (from countryMasterTB in _readOnlyUnitOfWork.CountryMasterRepository.GetAllAsQuerable()
                        select new CountryMasterDto
                        {
                            ID = countryMasterTB.ID,
                            CountryName = countryMasterTB.CountryName,
                            CountryCode = countryMasterTB.CountryCode
                        }).ToList();
            return data;
        }
        public async Task<List<StateMasterDto>> GetState(StateMasterDto request)
        {
            var data = (from stateMasterTB in _readOnlyUnitOfWork.StateMasterRepository.GetAllAsQuerable()
                        where stateMasterTB.CountryCode == request.CountryCode
                        join countryMasterTB in _readOnlyUnitOfWork.CountryMasterRepository.GetAllAsQuerable()
                       on stateMasterTB.CountryCode equals countryMasterTB.CountryCode
                        select new StateMasterDto
                        {
                            ID = stateMasterTB.ID,
                            StateName = stateMasterTB.StateName,
                            CountryCode = countryMasterTB.CountryCode

                        }).ToList();
            return data;
        }
        public async Task<List<CityMasterDto>> GetCity(CityMasterDto request)
        {
            var data = (from cityMasterTB in _readOnlyUnitOfWork.CityMasterRepository.GetAllAsQuerable()
                        where cityMasterTB.StateId == request.StateId
                        join stateMasterTB in _readOnlyUnitOfWork.StateMasterRepository.GetAllAsQuerable()
                     on cityMasterTB.StateId equals stateMasterTB.ID

                        select new CityMasterDto
                        {
                            ID = cityMasterTB.ID,
                            CityName = cityMasterTB.CityName,
                            StateId = stateMasterTB.ID
                        }).ToList();
            return data;
        }
    }
}
