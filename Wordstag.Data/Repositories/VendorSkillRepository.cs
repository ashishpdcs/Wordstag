using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Vendor;

namespace Wordstag.Data.Repositories
{
	public class VendorSkillRepository<TContext> : BaseRepository<VendorSkill, TContext>, IVendorSkillRepository<TContext> where TContext : IBaseContext
	{
		public VendorSkillRepository(TContext unit) : base(unit)
		{

		}
	}
}
