using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IUserRegisterRepository<TContext> : IBaseRepository<UserRegister, TContext> where TContext : IBaseContext
    {
    

    }
}
