using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Product
{
    public class DocumentDto
    {
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetDocumentDto
    {
        public Guid? Document_Id { get; set; }
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class SaveDocumentDto
    {
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateDocumentDto
    {
        public Guid Document_Id { get; set; }
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteDocumentDto
    {
        public Guid Document_Id { get; set; }
    }
}
