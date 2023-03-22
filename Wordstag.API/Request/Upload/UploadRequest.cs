namespace Wordstag.API.Request.Upload
{
    public class UploadRequest
    {
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Orignal_File { get; set; }
        public string? Updated_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetUploadRequest
    {
        public Guid Upload_Id { get; set; }
    }
    public class SaveUploadRequest
    {
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Orignal_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateUploadRequest
    {
        public Guid Upload_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Updated_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteUploadRequest
    {
        public Guid Upload_Id { get; set; }
    }
}
