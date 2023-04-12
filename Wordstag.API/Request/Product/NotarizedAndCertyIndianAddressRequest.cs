namespace Wordstag.API.Request.Product
{
    public class NotarizedAndCertyIndianAddressRequest
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
    public class SaveNotarizedAndCertyIndianAddressRequest
    {
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
       
    }
    public class GetNotarizedAndCertyIndianAddressRequest
    {
        public int Id { get; set; }
    }

    public class UpdateNotarizedAndCertyIndianAddressRequest
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }

    }
    public class DeleteNotarizedAndCertyIndianAddressRequest
    {
        public int Id { get; set; }
        

    }
}
