using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Vendor
{
    public class SaveVendorDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobileNo { get; set; }
        public string? AlternativePhoneNo { get; set; }
        public string? Address1 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? RegisteringAs { get; set; }
        public string? UploadCV { get; set; }
        public List<string> FromToLanguage { get; set; }
    }
    public class UpdateVendorDto
    {
        public Guid VendorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }
        public string? MobileNo { get; set; }
        public string? AlternativePhoneNo { get; set; }
        public string? Address1 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? RegisteringAs { get; set; }
        public string? UploadCV { get; set; }
    }
    public class DeleteVendorDto
    {
        public Guid VendorId { get; set; }
    }
	public class GetVendorSkill
	{
		public Guid SkillId { get; set; }
		public string? Skill { get; set; }
	}
    public class SaveSkillTableDto
    {
        public string? FromLanguage { get; set; }
        public string? Tolanguage { get; set; }
        public string? TableName { get; set; }
        public string? VendorId { get; set; }
        public Guid Id { get; set; }
      
    }
}
