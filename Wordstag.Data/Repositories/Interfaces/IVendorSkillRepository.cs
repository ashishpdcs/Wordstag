using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Vendor;

namespace Wordstag.Data.Repositories.Interfaces
{
	public interface IVendorSkillRepository<TContext> : IBaseRepository<VendorSkill, TContext> where TContext : IBaseContext
	{
	}
}
