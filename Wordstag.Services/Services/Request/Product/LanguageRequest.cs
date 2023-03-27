namespace Wordstag.API.Request.Product
{
    public class LanguageRequest
    {
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetLanguageRequest
    {
        public Guid LanguageId { get; set; }
    }
    public class SaveLanguageRequest
    {
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateLanguageRequest
    {
        public Guid LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteLanguageRequest
    {
        public Guid LanguageId { get; set; }
    }
}
