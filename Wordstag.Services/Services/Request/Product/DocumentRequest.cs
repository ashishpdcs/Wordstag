namespace Wordstag.API.Request.Product
{
    public class DocumentRequest
    {
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetDocumentRequest
    {
        public Guid DocumentId { get; set; }
    }
    public class SaveDocumentRequest
    {
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateDocumentRequest
    {
        public Guid DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteDocumentRequest
    {
        public Guid DocumentId { get; set; }
    }
}
