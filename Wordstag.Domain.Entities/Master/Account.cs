using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.Master
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public Guid DId { get; set; }
        public string? Name { get; set; }
        public string? Subdomain { get; set; }
        public string? DbDomain { get; set; }
        public int LicenseCount { get; set; }
        public string? ProductType { get; set; }
        public bool IsEXCEL { get; set; }
        public string? Status { get; set; }
        public string? SetupQRCodeUrl { get; set; }
    }
}
