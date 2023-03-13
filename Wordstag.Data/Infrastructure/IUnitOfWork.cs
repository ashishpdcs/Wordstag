using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Data.Contexts;

namespace Wordstag.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> where TContext : IBaseContext
    {
        IAccountsRepository<TContext> AccountsRepository { get; }
        IUserRegisterRepository<TContext> UserRegisterRepository { get; }

        IRefreshTokenRepository<TContext> RefreshTokenRepository { get; }
        Task<int> CommitAsync();

    }
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : IBaseContext
    {
        public TContext Context { get; }
        public IAccountsRepository<TContext> AccountsRepository { get; }
        public IUserRegisterRepository<TContext> UserRegisterRepository { get; }

        public IRefreshTokenRepository<TContext> RefreshTokenRepository { get; }

        public UnitOfWork(TContext context, IAccountsRepository<TContext> accountsRepository, IUserRegisterRepository<TContext> _userRegisterRepository, IRefreshTokenRepository<TContext> refreshTokenRepository)
        {
            this.Context = context;
            this.AccountsRepository = accountsRepository;
            this.UserRegisterRepository = _userRegisterRepository;
            this.RefreshTokenRepository = refreshTokenRepository;

        }
        public async Task<int> CommitAsync()
        {
            TContext checkType = default(TContext);
            if (checkType is ReadOnlyApplicationDbContext)
            {
                throw new Exception("This is a read-only context!");
            }
            return await this.Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}

