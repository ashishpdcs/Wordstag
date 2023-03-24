using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.UserSample;

namespace Wordstag.Data.Repositories
{
    public class UserSampleRepository<TContext> : BaseRepository<UserSample, TContext>, IUserSampleRepository<TContext> where TContext : IBaseContext
    {
        public UserSampleRepository(TContext unit) : base(unit)
        {

        }

    }
}
