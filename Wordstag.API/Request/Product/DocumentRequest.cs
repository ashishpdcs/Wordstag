namespace Wordstag.API.Request.Product
{
    public class DocumentRequest
    {
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetDocumentRequest
    {
        public Guid Document_Id { get; set; }
    }
    public class SaveDocumentRequest
    {
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateDocumentRequest
    {
        public Guid Document_Id { get; set; }
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteDocumentRequest
    {
        public Guid Document_Id { get; set; }
    }
}
