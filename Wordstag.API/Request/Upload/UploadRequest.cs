namespace Wordstag.API.Request.Upload
{
    public class UploadRequest
    {
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public string? FileName { get; set; }  
        public string? FileType { get; set; }
        public string? OrignalFile { get; set; }
        public string? UpdatedFile { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetUploadRequest
    {
        public Guid UploadId { get; set; }
    }
    public class SaveUploadRequest
    {
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? OrignalFile { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateUploadRequest
    {
        public Guid UploadId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? UpdatedFile { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteUploadRequest
    {
        public Guid UploadId { get; set; }
    }
}
