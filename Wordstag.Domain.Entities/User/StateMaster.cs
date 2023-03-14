using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.User
{
    [Table("StateMaster")]
    public class StateMaster
    {
        [Key]
        public int ID { get; set; }
        public string? StateName { get; set; }
        public string? CountryCode { get; set; }
    }
}

