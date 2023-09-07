using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.Vendor
{
    [Table("VendorRegister")]
    public class VendorRegister
    {
        [Key]
        public Guid VendorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePic { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobileNo { get; set; }
        public string? AlternativePhoneNo { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? RegisteringAs { get; set; }
        public string? UploadCV { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
      
        public bool? IsActive { get; set; }

    }
}

