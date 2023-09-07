using AutoMapper;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Vendor;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetLanguageDto>> GetLanguage(GetLanguageDto request)
        {
            var data = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                        where LanguageTB.LanguageId == request.LanguageId
                        select new GetLanguageDto
                        {
                            LanguageId = LanguageTB.LanguageId,
                            LanguageName = LanguageTB.LanguageName,
                            LanguageCode = LanguageTB.LanguageCode,
                            CreatedBy = LanguageTB.CreatedBy,
                            CreatedOn = LanguageTB.CreatedOn,
                            UpdatedBy = LanguageTB.UpdatedBy,
                            UpdatedOn = LanguageTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<List<GetLanguageDto>> GetAllLanguage()
        {
            var data = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                        select new GetLanguageDto
                        {
                            LanguageId = LanguageTB.LanguageId,
                            LanguageName = LanguageTB.LanguageName,
                            LanguageCode = LanguageTB.LanguageCode,
                        }).ToList();


            return data;



        }
        public async Task<List<GetLanguageJson>> GetAllLanguageDropdown(string? searchKeywords, string? type)
        {
            var allLanguages = _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable();

            if (!string.IsNullOrWhiteSpace(searchKeywords))
            {
                allLanguages = allLanguages.Where(language => language.LanguageName.StartsWith(searchKeywords));
            }

            var data = allLanguages.Select(language => new GetLanguageDto
            {
                LanguageId = language.LanguageId,
                LanguageName = language.LanguageName,
                LanguageCode = language.LanguageCode,
            }).ToList();

            var result = new List<GetLanguageJson>();
            if (type == "single")
            {
                // Return a single language
                if (data.Count > 0)
                {
                    var languagePairs = new List<object>();

                    foreach (var to in data)
                    {
                        result.Add(new GetLanguageJson
                        {
                            Id = to.LanguageId.ToString(),
                            Text = to.LanguageName
                        });
                    }

                    if (result.Count > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return new List<GetLanguageJson> { new GetLanguageJson { Id = null, Text = "No languages available." } };
                    }

                }
               
            }
            else if (type == "multiple")
            {
                // Return language pairs (from and to)
                var languagePairs = new List<string>();
                var toLanguages = _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable();

                foreach (var from in data)
                {
                    foreach (var to in toLanguages)
                    {
                        if (from.LanguageId != to.LanguageId)
                        {
                            string idString = $"id={from.LanguageId}|{to.LanguageId}";
                            string nameString = $"name={from.LanguageName} To {to.LanguageName}";
                            //  string concatenatedPair = $"{idString}     {nameString}";

                            //languagePairs.Add(concatenatedPair);
                            result.Add(new GetLanguageJson
                            {
                                Id = $"{from.LanguageId}|{to.LanguageId}",
                                Text = $"{from.LanguageName} To {to.LanguageName}"
                            });
                        }
                    }
                }

                if (result.Count > 0)
                {
                    return result;
                }
                else
                {
                    return new List<GetLanguageJson> { new GetLanguageJson { Id = null, Text = "No language pairs available." } };
                }
            }
            else
            {
                return new List<GetLanguageJson> { new GetLanguageJson { Id = null, Text = "Invalid kk parameter" } };
            }
            return null;
        }



        public async Task<Guid> SaveLanguage(SaveLanguageDto request)
        {
            var saveLanguage = new Language()
            {
                LanguageId = Guid.NewGuid(),
                LanguageName = request.LanguageName,
                LanguageCode = request.LanguageCode,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow
            };
            await _readWriteUnitOfWork.LanguageRepository.AddAsync(saveLanguage);
            await _readWriteUnitOfWork.CommitAsync();

            return saveLanguage.LanguageId;
        }

        public async Task<bool> UpdateLanguage(UpdateLanguageDto request)
        {
            var data = await _readWriteUnitOfWork.LanguageRepository.GetFirstOrDefaultAsync(x => x.LanguageId == request.LanguageId);
            if (data != null)
            {
                data.LanguageName = request.LanguageName;
                data.LanguageCode = request.LanguageCode;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GetLanguageDto>> GetAllLanguageName()
        {
            var data = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                        select new GetLanguageDto
                        {
                            LanguageId = LanguageTB.LanguageId,
                            LanguageName = LanguageTB.LanguageName,
                            LanguageCode = LanguageTB.LanguageCode,
                            CreatedBy = LanguageTB.CreatedBy,
                            CreatedOn = LanguageTB.CreatedOn,
                            UpdatedBy = LanguageTB.UpdatedBy,
                            UpdatedOn = LanguageTB.UpdatedOn,
                        }).ToList();
            return data;
        }

        //public async Task<bool> DeleteLanguage(DeleteLanguageDto request)
        //{
        //    var data = await _readWriteUnitOfWork.LanguageRepository.GetFirstOrDefaultAsync(x => x.LanguageId == request.LanguageId);
        //    if (data != null)
        //    {
        //        data.IsDeleted = true;
        //        await _readWriteUnitOfWork.CommitAsync();
        //        return true;
        //    }
        //    return false;
        //}

    }
}
