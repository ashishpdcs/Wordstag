using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.User;
using Wordstag.Domain.Entities.Vendor;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.Vendor;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;
using Wordstag.Utility.Exceptions;

namespace Wordstag.Services.Services
{
    public class VendorRegisterService : IVendorRegisterService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public VendorRegisterService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
          IUnitOfWork<MasterDbContext> masterDBContext, IMapper mapper,
          IUnitOfWork<ReadWriteApplicationDbContext> readWriteUnitOfWork,
          ReadWriteApplicationDbContext readWriteUnitOfWorkSP, IOptions<AppSettings> appSettings)
        {
            _readOnlyUnitOfWork = readOnlyUnitOfWork;
            _masterDBContext = masterDBContext;
            _readWriteUnitOfWork = readWriteUnitOfWork;
            _mapper = mapper;
            _readWriteUnitOfWorkSP = readWriteUnitOfWorkSP;
            _appSettings = appSettings.Value;
        }


        public async Task<Guid> SaveVendorRegister(SaveVendorDto request)
        {

            //Save Data in UserRegister Table.
            var hashPassword = GenericMethods.GetHash(request.Password);
            var saveVendorRegister = new VendorRegister()
            {
                VendorId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = hashPassword,
                MobileNo = request.MobileNo,
                AlternativePhoneNo = request.AlternativePhoneNo,
                Address1 = request.Address1,
                City = request.City,
                State = request.State,
                Country = request.Country,
                Zipcode = request.Zipcode,
                Gender = request.Gender,
                RegisteringAs = request.RegisteringAs,
                UploadCV = request.UploadCV,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.VendorRegisterRepository.AddAsync(saveVendorRegister);

            await _readWriteUnitOfWork.CommitAsync();
            /* using (TransactionScope scope = new TransactionScope())
             {*/
            foreach (string fromToLanguageString in request.FromToLanguage)
            {
                List<string> extractedValues = new List<string>();
                string[] parts = fromToLanguageString.Split('|');
                if (parts.Length >= 2)
                {
                    var message = "Fail";
                    Guid newId = Guid.NewGuid();
                    string skillName = parts[0].Trim();
                    Guid fromLanguage = new Guid(parts[1].Trim());
                    Guid? toLanguage = null; // Use nullable Guid to allow for missing 'toLanguage'

                    if (parts.Length >= 3 && Guid.TryParse(parts[2].Trim(), out Guid parsedToLanguage))
                    {
                        toLanguage = parsedToLanguage;
                    }

                    skillName = skillName.Replace(" ", "");
                    // string fromLanguage = parts[1].Trim();
                    //   string toLanguage = parts[2].Trim();
                    extractedValues.Add(skillName);
                    // extractedValues.Add(fromLanguage);
                    extractedValues.Add(toLanguage.ToString());

                    // Assuming you have an instance of _readWriteUnitOfWorkSP for database access
                    /* _readWriteUnitOfWorkSP.LoadStoredProc("SaveVendorRegister")
                         .WithSqlParam("@TableName", skillName)
                         .WithSqlParam("@Id", newId)
                         .WithSqlParam("@FromLanguage", fromLanguage)
                         .WithSqlParam("@ToLanguage", toLanguage)
                         .WithSqlParam("@VendorId", saveVendorRegister.VendorId);*/


                    string connectionString = _appSettings.ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Insert data into a table with fields Id, Name, and UserCode
                        string skillTable = skillName;
                        string insertQuery;

                        if (skillTable == "Interpreter" || skillTable == "Localization Expert" || skillTable == "Translator")
                        {
                            insertQuery = $"INSERT INTO {skillTable} (Id, FromLanguage, ToLanguage, VendorId) VALUES (@Id, @FromLanguage, @ToLanguage, @VendorId)";
                        }
                        else
                        {
                            insertQuery = $"INSERT INTO {skillTable} (Id, FromLanguage, VendorId) VALUES (@Id, @FromLanguage, @VendorId)";
                        }


                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Replace these with your actual values
                            command.Parameters.AddWithValue("@Id", newId); // Example: replace with an actual Id
                            if (skillTable == "Interpreter" || skillTable == "Localization Expert" || skillTable == "Translator")
                            {
                                command.Parameters.AddWithValue("@ToLanguage", toLanguage); // Only add this parameter conditionally
                            }
                            command.Parameters.AddWithValue("@FromLanguage", fromLanguage);
                            command.Parameters.AddWithValue("@VendorId", saveVendorRegister.VendorId);// Example: replace with an actual UserCode

                            try
                            {
                                int rowsAffected = command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {

                            }
                            /*if (rowsAffected > 0)
                            {
                                Console.WriteLine("Data inserted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Data insertion failed.");
                            }*/
                        }

                        connection.Close();
                    }



                    // Do something with rawCOAGroupData if needed
                }
            }
            /*}*/

            

            return saveVendorRegister.VendorId;
        }
        public async Task<bool> UpdateVendorRegister(UpdateVendorDto request)
        {
            var data = await _readWriteUnitOfWork.VendorRegisterRepository.GetFirstOrDefaultAsync(x => x.VendorId == request.VendorId);
            if (data != null)
            {
                data.FirstName = request.FirstName;
                data.LastName = request.LastName;
                data.MobileNo = request.MobileNo;
                data.AlternativePhoneNo = request.AlternativePhoneNo;
                data.Address1 = request.Address1;
                data.City = request.City;
                data.State = request.State;
                data.Country = request.Country;
                data.Zipcode = request.Zipcode;
                data.Gender = request.Gender;
                data.RegisteringAs = request.RegisteringAs;
                data.UploadCV = request.UploadCV;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.VendorRegisterRepository.AttachUpdateEntity(data);
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteVendorRegister(DeleteVendorDto request)
        {
            var data = await _readWriteUnitOfWork.VendorRegisterRepository.GetFirstOrDefaultAsync(x => x.VendorId == request.VendorId);
            if (data != null)
            {
                data.IsDeleted = true;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GetVendorSkill>> GetAllVendorSkill()
        {
            var data = (from vendorSkills in _readWriteUnitOfWork.VendorSkillRepository.GetAllAsQuerable()
                        where vendorSkills.IsDeleted == false
                        select new GetVendorSkill
                        {
                            SkillId = vendorSkills.SkillId,
                            Skill = vendorSkills.Skill
                        }).ToList();
            return data;
        }
        public async Task<List<GetVendorSkill>> GetVendorSkill(Guid VendorSkillId)
        {
            var data = (from vendorSkills in _readWriteUnitOfWork.VendorSkillRepository.GetAllAsQuerable()
                        where vendorSkills.SkillId == VendorSkillId && vendorSkills.IsDeleted == false
                        select new GetVendorSkill
                        {
                            SkillId = vendorSkills.SkillId,
                            Skill = vendorSkills.Skill
                        }).ToList();
            return data;
        }
    }
}
