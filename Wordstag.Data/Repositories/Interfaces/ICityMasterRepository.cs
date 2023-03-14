using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface ICityMasterRepository<TContext> : IBaseRepository<CityMaster, TContext> where TContext : IBaseContext
    {

    }
}
