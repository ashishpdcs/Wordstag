using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Entities.UserSample
{
    public class UserSampleDto
    {
        public Guid? Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetUserSampleDto
    {
        public Guid? Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
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
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
    }
    public class UpdateUserSampleDto
    {
        public Guid? Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class DeleteUserSampleDto
    {
        public Guid Id { get; set; }
    }
}
