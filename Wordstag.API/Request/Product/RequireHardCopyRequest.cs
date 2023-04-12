namespace Wordstag.API.Request.Product
{
    public class RequireHardCopyRequest
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
    public class SaveRequireHardCopyRequest
    {
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
       
    }
    public class GetRequireHardCopyRequest
    {
        public int Id { get; set; }
    }

    public class UpdateRequireHardCopyRequest
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }

    }
    public class DeleteRequireHardCopyRequest
    {
        public int Id { get; set; }
        

    }
}
