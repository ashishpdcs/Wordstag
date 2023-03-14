using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Data.Contexts;

namespace Wordstag.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> where TContext : IBaseContext
    {
        IAccountsRepository<TContext> AccountsRepository { get; }
        IUserRegisterRepository<TContext> UserRegisterRepository { get; }

        IRefreshTokenRepository<TContext> RefreshTokenRepository { get; }
        ICityMasterRepository<TContext> CityMasterRepository { get; }
        ICountryMasterRepository<TContext> CountryMasterRepository { get; }
        IStateMasterRepository<TContext> StateMasterRepository { get; }
        Task<int> CommitAsync();

    }
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : IBaseContext
    {
        public TContext Context { get; }
        public IAccountsRepository<TContext> AccountsRepository { get; }
        public IUserRegisterRepository<TContext> UserRegisterRepository { get; }

        public IRefreshTokenRepository<TContext> RefreshTokenRepository { get; }
        public ICityMasterRepository<TContext> CityMasterRepository { get; }
        public ICountryMasterRepository<TContext> CountryMasterRepository { get; }
        public IStateMasterRepository<TContext> StateMasterRepository { get; }

        public UnitOfWork(TContext context, IAccountsRepository<TContext> accountsRepository,
            IUserRegisterRepository<TContext> _userRegisterRepository,
            IRefreshTokenRepository<TContext> refreshTokenRepository,
            ICityMasterRepository<TContext> cityMasterRepository,
            IStateMasterRepository<TContext> stateMasterRepository,
            ICountryMasterRepository<TContext> countryMasterRepository)
        {
            this.Context = context;
            this.AccountsRepository = accountsRepository;
            this.UserRegisterRepository = _userRegisterRepository;
            this.RefreshTokenRepository = refreshTokenRepository;
            this.CountryMasterRepository = countryMasterRepository;
            this.StateMasterRepository = stateMasterRepository;
            this.CityMasterRepository = cityMasterRepository;

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

