using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Common;

namespace Wordstag.Services.Entities.Product
{
    public class DocumentDto
    {
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetDocumentDto : PaginationDto
    {
        public Guid? DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class SaveDocumentDto
    {
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateDocumentDto
    {
        public Guid DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteDocumentDto
    {
        public Guid DocumentId { get; set; }
    }
}
