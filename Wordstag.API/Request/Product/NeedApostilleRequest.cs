namespace Wordstag.API.Request.Product
{
    public class NeedApostilleRequest
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
    public class SaveNeedApostilleRequest
    {
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
       
    }
    public class GetNeedApostilleRequest
    {
        public int Id { get; set; }
    }

    public class UpdateNeedApostilleRequest
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }

    }
    public class DeleteNeedApostilleRequest
    {
        public int Id { get; set; }
        

    }
}
