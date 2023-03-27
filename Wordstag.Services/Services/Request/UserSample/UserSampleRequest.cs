namespace Wordstag.API.Request.UserSample
{
    public class UserSampleRequest
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
    public class GetUserSampleRequest
    {
        public Guid Id { get; set; }
    }
    public class SaveUserSampleRequest
    {
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateUserSampleRequest
    {
        public Guid Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteUserSampleRequest
    {
        public Guid Id { get; set; }
    }
}
