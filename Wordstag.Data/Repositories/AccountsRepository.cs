using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Domain.Entities.Master;

namespace Wordstag.Data.Repositories
{
    public class AccountsRepository<TContext> : BaseRepository<Account, TContext>, IAccountsRepository<TContext> where TContext : IBaseContext
    {
        public AccountsRepository(TContext unit) : base(unit)
        {

        }

    }
}
