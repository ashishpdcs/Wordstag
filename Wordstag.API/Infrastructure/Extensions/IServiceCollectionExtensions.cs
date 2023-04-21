using Microsoft.EntityFrameworkCore;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Data.Repositories;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;
using System.Reflection;
using NetCore.AutoRegisterDi;

namespace Wordstag.API.Infrastructure.Extensions
{
    public  static class IServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            var assembliesToScan = new[]{
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(IBaseService))
            };

            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                 .Where(c => c.Name.EndsWith("Service"))
                 .AsPublicImplementedInterfaces();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAccountsRepository<>), typeof(AccountsRepository<>));
            services.AddTransient(typeof(IUserRegisterRepository<>), typeof(UserRegisterRepository<>));
            services.AddTransient(typeof(IRefreshTokenRepository<>), typeof(RefreshTokenRepository<>));
            services.AddTransient(typeof(ICountryMasterRepository<>), typeof(CountryMasterRepository<>));
            services.AddTransient(typeof(IStateMasterRepository<>), typeof(StateMasterRepository<>));
            services.AddTransient(typeof(ICityMasterRepository<>), typeof(CityMasterRepository<>));
            services.AddTransient(typeof(IProductTypeRepository<>), typeof(ProductTypeRepository<>));
            services.AddTransient(typeof(IProductRepository<>), typeof(ProductRepository<>));
            services.AddTransient(typeof(ILanguageRepository<>), typeof(LanguageRepository<>));
            services.AddTransient(typeof(IDocumentRepository<>), typeof(DocumentRepository<>));
            services.AddTransient(typeof(IOrderRepository<>), typeof(OrderRepository<>));
            services.AddTransient(typeof(IUploadRepository<>), typeof(UploadRepository<>));
            services.AddTransient(typeof(IUserSampleRepository<>), typeof(UserSampleRepository<>));
            services.AddTransient(typeof(IPlanRepository<>), typeof(PlanRepository<>));
            services.AddTransient(typeof(IProductCertificateRepository<>), typeof(ProductCertificateRepository<>));
            services.AddTransient(typeof(INotarizedAndCertyIndianAddressRepository<>), typeof(NotarizedAndCertyIndianAddressRepository<>));
            services.AddTransient(typeof(INeedApostilleRepository<>), typeof(NeedApostilleRepository<>));
            services.AddTransient(typeof(IRequireHardCopyRepository<>), typeof(RequireHardCopyRepository<>));
            services.AddTransient(typeof(IProductServiceRepository<>), typeof(ProductServiceRepository<>));
        }

        public static void ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MasterDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(Constants.MasterDBConnectionName));
            });

            //DependencyResolver.Current.GetService<IAuthProviderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddDbContext<AuditLogDbContext>(options => { });

            services.AddDbContext<ReadWriteApplicationDbContext>(options => { });
            services.AddDbContext<ReadOnlyApplicationDbContext>(options => { });

            services.AddScoped<Func<ReadOnlyApplicationDbContext>>((provider) => () => provider.GetService<ReadOnlyApplicationDbContext>());
            services.AddScoped<Func<ReadWriteApplicationDbContext>>((provider) => () => provider.GetService<ReadWriteApplicationDbContext>());
            services.AddScoped<Func<AuditLogDbContext>>((provider) => () => provider.GetService<AuditLogDbContext>());
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            //var urls = settings.ClientAppUrl.Split(",", StringSplitOptions.RemoveEmptyEntries);

            services.AddCors(options =>
            {
                options.AddPolicy("WordstagCors", b =>
                {
                    b.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .WithOrigins("https://localhost:4000")
                    .SetIsOriginAllowed((host) => true);
                });
            });
        }
    }
}
