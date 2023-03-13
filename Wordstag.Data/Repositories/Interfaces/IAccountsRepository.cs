using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IAccountsRepository<TContext> : IBaseRepository<Account, TContext> where TContext : IBaseContext
    {
    }
}
