
using Wordstag.Domain.Entities.User;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Entities.Upload
{
    public class UploadDto
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
    public class GetUploadDto
    {
        public Guid Upload_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Orignal_File { get; set; }
        public string? Updated_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
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
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Orignal_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class UpdateUploadDto
    {
        public Guid Upload_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Updated_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class DeleteUploadDto
    {
        public Guid Upload_Id { get; set; }
    }
}
