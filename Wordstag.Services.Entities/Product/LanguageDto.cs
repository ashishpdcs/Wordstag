using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Product
{
    public class LanguageDto
    {
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetLanguageDto
    {
        public Guid? LanguageId { get; set; }
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class SaveLanguageDto
    {
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateLanguageDto
    {
        public Guid LanguageId { get; set; }
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteLanguageDto
    {
        public Guid LanguageId { get; set; }
    }
}
