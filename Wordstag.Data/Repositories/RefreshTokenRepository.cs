using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Data.Repositories
{
    public class RefreshTokenRepository<TContext> : BaseRepository<RefreshToken, TContext>, IRefreshTokenRepository<TContext> where TContext : IBaseContext
    {
        public RefreshTokenRepository(TContext context) : base(context)
        {
        }
    }
}
