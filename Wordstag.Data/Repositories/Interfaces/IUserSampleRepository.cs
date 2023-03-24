using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.UserSample;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IUserSampleRepository<TContext> : IBaseRepository<UserSample, TContext> where TContext : IBaseContext
    {
    

    }
}
