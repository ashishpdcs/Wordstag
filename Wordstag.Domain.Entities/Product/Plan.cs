using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.Product
{
        [Table("ProductPlan")]
        public class Plan
        {
            [Key]
            public Guid Id { get; set; }
            public string? PlanType { get; set; }
    }
}
