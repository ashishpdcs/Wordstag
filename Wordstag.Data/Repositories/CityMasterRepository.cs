using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Data.Repositories
{
    public class CityMasterRepository<TContext> : BaseRepository<CityMaster, TContext>, ICityMasterRepository<TContext> where TContext : IBaseContext
    {
        public CityMasterRepository(TContext unit) : base(unit)
        {

        }
    }
}
