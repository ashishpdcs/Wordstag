namespace Wordstag.API.Request.Master
{

    public class StateMasterRequest
    {
        public string? CountryCode { get; set; }

    }
    public class CityMasterRequest
    {
        public int? StateId { get; set; }

    }
    public class ApproveAndUnApproveRequest
    {
        public Guid? User_SampleID { get; set; }
        public string? Approve { get; set; }

        public Guid? Approve_Id { get; set; }
    }
}
