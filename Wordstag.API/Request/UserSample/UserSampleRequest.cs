namespace Wordstag.API.Request.UserSample
{
    public class UserSampleRequest
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
    public class GetUserSampleRequest
    {
        public Guid Id { get; set; }
    }
    public class SaveUserSampleRequest
    {
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateUserSampleRequest
    {
        public Guid Id { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteUserSampleRequest
    {
        public Guid Id { get; set; }
    }
    public class GetUserSampleApprove
    {
        public string? Approve { get; set; }
    }
}
