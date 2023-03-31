using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Entities.UserSample
{
    public class UserSampleDto
    {
        public Guid? Id { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetUserSampleDto : PaginationDto
    {
        public Guid? Id { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<GetLanguageDto> getLanguageDtos { get; set; }
        public ICollection<GetUserRegisterDto> getUserRegisterDtos { get; set; }
        public ICollection<GetUploadDto> getUploadDtos { get; set; }
        public ICollection<GetProductTypeDto> getProductTypeDtos { get; set; }

    }
    public class SaveUserSampleDto
    {
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
    }
    public class UpdateUserSampleDto
    {
        public Guid? Id { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class DeleteUserSampleDto
    {
        public Guid Id { get; set; }
    }
}
