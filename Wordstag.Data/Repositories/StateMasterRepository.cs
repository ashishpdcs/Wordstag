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
    public class StateMasterRepository<TContext> : BaseRepository<StateMaster, TContext>, IStateMasterRepository<TContext> where TContext : IBaseContext
    {
        public StateMasterRepository(TContext unit) : base(unit)
        {

        }
    }
}
