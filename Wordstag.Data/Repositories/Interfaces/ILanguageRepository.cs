using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface ILanguageRepository<TContext> : IBaseRepository<Language, TContext> where TContext : IBaseContext
    {

    }
}
