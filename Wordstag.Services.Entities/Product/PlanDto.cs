using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Product
{
    public class GetPlanDto
    {
        public Guid Id { get; set; }
        public string? PlanType { get; set; }
    }
}
