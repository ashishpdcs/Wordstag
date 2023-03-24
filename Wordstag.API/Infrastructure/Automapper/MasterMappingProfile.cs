using AutoMapper;
using Wordstag.Services.Entities.Master;
using Wordstag.API.Request.Master;
using Wordstag.API.Requests.User;
using Wordstag.Domain.Entities.User;
using Wordstag.Services.Entities.User;
using Wordstag.Domain.Entities.UserSample;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class MasterMappingProfile : Profile
    {
        public MasterMappingProfile()
        {
            CreateMap<CityMasterRequest, CityMasterDto>();
            CreateMap<CityMaster, CityMasterDto>().ReverseMap();

            CreateMap<StateMasterRequest, StateMasterDto>();
            CreateMap<StateMaster, StateMasterDto>().ReverseMap();

            CreateMap<ApproveAndUnApproveRequest, ApproveAndUnApproveDto>();
            CreateMap<UserSample, ApproveAndUnApproveDto>().ReverseMap();
        }
    }
}
