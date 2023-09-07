namespace Wordstag.API.Request.Vendor
{
    public class SaveVendorRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Password { get; set; }
        public string? AlternativePhoneNo { get; set; }
        public string? Address1 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? RegisteringAs { get; set; }
        public string? UploadCV { get; set; }
        public List<string> FromToLanguage{ get; set; }
    }
    public class UpdateVendorRequest
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
    public class DeleteVendorRequest
    {
        public Guid VendorId { get; set; }
    }

	public class GetVendorSkillRequest
	{
		public Guid VendorSkillId { get; set; }
	}
}
