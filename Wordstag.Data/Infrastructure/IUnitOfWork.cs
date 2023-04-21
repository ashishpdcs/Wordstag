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
        IProductTypeRepository<TContext> ProductTypeRepository { get; }
        IProductRepository<TContext> ProductRepository { get; }
        ILanguageRepository<TContext> LanguageRepository { get; }
        IDocumentRepository<TContext> DocumentRepository { get; }
        IOrderRepository<TContext> OrderRepository { get; }
        IUploadRepository<TContext> UploadRepository { get; }
        IUserSampleRepository<TContext> UserSampleRepository { get; }
        IPlanRepository<TContext> PlanRepository { get; }
        IProductCertificateRepository<TContext> productCertificateRepository { get; }
        INotarizedAndCertyIndianAddressRepository<TContext> notarizedAndCertyIndianAddressRepository { get; }
        INeedApostilleRepository<TContext> needApostilleRepository { get; }
        IRequireHardCopyRepository<TContext> requireHardCopyRepository{ get; }
        IProductServiceRepository<TContext> ProductServiceRepository { get; }

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
        public IProductTypeRepository<TContext> ProductTypeRepository { get; }
        public IProductRepository<TContext> ProductRepository { get; }
        public ILanguageRepository<TContext> LanguageRepository { get; }
        public IDocumentRepository<TContext> DocumentRepository { get; }
        public IOrderRepository<TContext> OrderRepository { get; }
        public IUploadRepository<TContext> UploadRepository { get; }
        public IUserSampleRepository<TContext> UserSampleRepository { get; }
        public IPlanRepository<TContext> PlanRepository { get; }
        public IProductCertificateRepository<TContext> productCertificateRepository{ get; }
        public INotarizedAndCertyIndianAddressRepository<TContext> notarizedAndCertyIndianAddressRepository { get; }
        public INeedApostilleRepository<TContext> needApostilleRepository { get; }
        public IRequireHardCopyRepository<TContext> requireHardCopyRepository { get; }
       public IProductServiceRepository<TContext> ProductServiceRepository { get; }




        public UnitOfWork(TContext context, IAccountsRepository<TContext> accountsRepository,
            IUserRegisterRepository<TContext> _userRegisterRepository,
            IRefreshTokenRepository<TContext> refreshTokenRepository,
            ICityMasterRepository<TContext> cityMasterRepository,
            IStateMasterRepository<TContext> stateMasterRepository,
            ICountryMasterRepository<TContext> countryMasterRepository,
            IProductTypeRepository<TContext> productTypeRepository,
            IProductRepository<TContext> productRepository,
            ILanguageRepository<TContext> languageRepository, 
            IDocumentRepository<TContext> documentRepository,
            IOrderRepository<TContext> orderRepository,
            IUploadRepository<TContext> uploadRepository,
            IUserSampleRepository<TContext> userSampleRepository,
            IPlanRepository<TContext> planRepository,
            IProductCertificateRepository<TContext> productCertificateRepository,
            INotarizedAndCertyIndianAddressRepository<TContext> notarizedAndCertyIndianAddressRepository,
            INeedApostilleRepository<TContext> needApostilleRepository,
            IRequireHardCopyRepository<TContext> requireHardCopyRepository
          , IProductServiceRepository<TContext> productServiceRepository
            )
        {
            this.Context = context;
            this.AccountsRepository = accountsRepository;
            this.UserRegisterRepository = _userRegisterRepository;
            this.RefreshTokenRepository = refreshTokenRepository;
            this.CountryMasterRepository = countryMasterRepository;
            this.StateMasterRepository = stateMasterRepository;
            this.CityMasterRepository = cityMasterRepository;
            this.ProductTypeRepository = productTypeRepository;
            this.ProductRepository = productRepository;
            this.LanguageRepository = languageRepository;
            this.DocumentRepository = documentRepository;
            this.OrderRepository = orderRepository;
            this.UploadRepository = uploadRepository;
            this.UserSampleRepository = userSampleRepository;
            this.PlanRepository = planRepository;
            this.productCertificateRepository = productCertificateRepository;
            this.notarizedAndCertyIndianAddressRepository = notarizedAndCertyIndianAddressRepository;
            this.needApostilleRepository = needApostilleRepository;
            this.requireHardCopyRepository = requireHardCopyRepository;
            this.ProductServiceRepository = productServiceRepository;
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

