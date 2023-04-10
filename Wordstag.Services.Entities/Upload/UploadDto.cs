using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Entities.Upload
{
    public class UploadDto
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
    public class GetUploadDto : PaginationDto
    {
        public Guid UploadId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? OrignalFile { get; set; }
        public string? UpdatedFile { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public List<GetUserRegisterDto> userRegisters { get; set; }
        public List<GetProductDto> productDto { get; set; }
        public List<GetLanguageDto> LanguageDtos { get; set; }
    }
    public class SaveUploadDto
    {
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? OrignalFile { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class UpdateUploadDto
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
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class DeleteUploadDto
    {
        public Guid UploadId { get; set; }
    }
}
