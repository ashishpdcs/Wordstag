using AutoMapper;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.User;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.UserSample;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.Services.Services
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public UserRegisterService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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

        public async Task<UserRegisterDto> UserRegisterAsync(UserRegisterDto request, string ipAddress)
        {
            var userRegister = await _readOnlyUnitOfWork.UserRegisterRepository.GetFirstOrDefaultAsync(x => x.FirstName == request.FirstName);
            var userRegisterDto = _mapper.Map<UserRegister, UserRegisterDto>(userRegister);
            return userRegisterDto;
        }

        public async Task<List<GetUserRegisterDto>> GetUserRegister(GetUserRegisterDto request)
        {
            var data = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                        where userRegisterTB.UserId == request.UserId && userRegisterTB.IsDeleted == false && userRegisterTB.UserType == request.UserType
                        select new GetUserRegisterDto
                        {
                            UserId = userRegisterTB.UserId,
                            FirstName = userRegisterTB.FirstName,
                            LastName = userRegisterTB.LastName,
                            Password = userRegisterTB.Password,
                            EmailAddress = userRegisterTB.EmailAddress,
                            MobileNo = userRegisterTB.MobileNo,
                            Gender = userRegisterTB.Gender,
                            UserToken = userRegisterTB.UserToken,
                            UserType = userRegisterTB.UserType,
                            Isverified = userRegisterTB.Isverified,
                        }).ToList();
            return data;
        }
        public async Task<GenericList<GetUserRegisterDto>> GetAllUserRegister(PaginationDto paginationDto)
        {
            var dataQuery = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                        where userRegisterTB.IsDeleted == false && userRegisterTB.UserType == "User"
                        select new GetUserRegisterDto
                        {
                            UserId = userRegisterTB.UserId,
                            FirstName = userRegisterTB.FirstName,
                            LastName = userRegisterTB.LastName,
                            Password = userRegisterTB.Password,
                            EmailAddress = userRegisterTB.EmailAddress,
                            MobileNo = userRegisterTB.MobileNo,
                            Gender = userRegisterTB.Gender,
                            UserToken = userRegisterTB.UserToken,
                            Address = userRegisterTB.Address,
                            CityId = userRegisterTB.CityId,
                            StateId = userRegisterTB.StateId,
                            CountryId = userRegisterTB.CountryId,
                            Zipcode = userRegisterTB.Zipcode,
                            UserType = userRegisterTB.UserType,
                            Isverified = userRegisterTB.Isverified,
                        });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.UserName.Contains(paginationDto.GlobalSearch)
                || (x.UserName != null && x.UserName.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetUserRegisterDto>();
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
        public async Task<List<GetUserRegisterDto>> SaveUserRegister(SaveUserRegisterDto request)
        {
            //Save Data in UserRegister Table.
            var hashPassword = GenericMethods.GetHash(request.Password);
            var saveUserRegister = new UserRegister()
            {
                UserId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = hashPassword,
                EmailAddress = request.EmailAddress,
                MobileNo = request.MobileNo,
                Address = request.Address,
                CityId = request.CityId,
                StateId = request.StateId,
                CountryId = request.CountryId,
                Zipcode = request.Zipcode,
                Gender = request.Gender,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                UserType = request.UserType,
                Isverified = request.Isverified
            };
            await _readWriteUnitOfWork.UserRegisterRepository.AddAsync(saveUserRegister);
            await _readWriteUnitOfWork.CommitAsync();

            var data = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                        where userRegisterTB.UserId == saveUserRegister.UserId && userRegisterTB.IsDeleted == false
                        select new GetUserRegisterDto
                        {
                            UserId = userRegisterTB.UserId,
                            FirstName = userRegisterTB.FirstName,
                            LastName = userRegisterTB.LastName,
                            Password = userRegisterTB.Password,
                            EmailAddress = userRegisterTB.EmailAddress,
                            MobileNo = userRegisterTB.MobileNo,
                            Gender = userRegisterTB.Gender,
                            UserToken = userRegisterTB.UserToken,
                            UserType = userRegisterTB.UserType,
                            Isverified = userRegisterTB.Isverified,
                        }).ToList();
            return data;
        }

        public async Task<bool> UpdateUserRegister(UpdateUserRegisterDto request)
        {
            var data = await _readWriteUnitOfWork.UserRegisterRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId);
            if (data != null)
            {
                data.FirstName = request.FirstName;
                data.LastName = request.LastName;
                data.EmailAddress = request.EmailAddress;
                data.MobileNo = request.MobileNo;
                data.Gender = request.Gender;
                data.UserToken = request.UserToken;
                data.Address = request.Address;
                data.CityId = request.CityId;
                data.StateId = request.StateId;
                data.CountryId = request.CountryId;
                data.Zipcode = request.Zipcode;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserRegister(DeleteUserRegisterDto request)
        {
            var data = await _readWriteUnitOfWork.UserRegisterRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId);
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
