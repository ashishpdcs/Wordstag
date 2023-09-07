using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.Vendor
{
	[Table("VendorSkill")]
	public class VendorSkill
	{
		[Key]
		public Guid SkillId { get; set; }
		public string? Skill { get; set; }

		public DateTime CreatedOn { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public string? UpdatedBy { get; set; }
		public bool? IsDeleted { get; set; }
	}
}
