namespace Wordstag.Services.Entities.Master
{
   
    public class CountryMasterDto
    {
        public int ID { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }


    }

    public class StateMasterDto
    {
        public int ID { get; set; }
        public string? StateName { get; set; }
        public string? CountryCode { get; set; }
    }
    public class CityMasterDto
    {
        public int ID { get; set; }
        public string? CityName { get; set; }
        public int? StateId { get; set; }
    }
    public class ApproveAndUnApproveDto
    {
        public Guid? User_SampleID { get; set; }
        public string? Approve { get; set; }

        public Guid? Approve_Id { get; set; }
    }
}
