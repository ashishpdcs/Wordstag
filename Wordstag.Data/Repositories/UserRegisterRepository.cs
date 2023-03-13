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
    public class UserRegisterRepository<TContext> : BaseRepository<UserRegister, TContext>, IUserRegisterRepository<TContext> where TContext : IBaseContext
    {
        public UserRegisterRepository(TContext unit) : base(unit)
        {

        }

    }
}
