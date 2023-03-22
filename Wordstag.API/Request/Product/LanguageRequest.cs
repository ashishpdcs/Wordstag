namespace Wordstag.API.Request.Product
{
    public class LanguageRequest
    {
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetLanguageRequest
    {
        public Guid LanguageId { get; set; }
    }
    public class SaveLanguageRequest
    {
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateLanguageRequest
    {
        public Guid LanguageId { get; set; }
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteLanguageRequest
    {
        public Guid LanguageId { get; set; }
    }
}
