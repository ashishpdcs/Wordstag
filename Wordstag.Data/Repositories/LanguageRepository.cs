using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class LanguageRepository<TContext> : BaseRepository<Language, TContext>, ILanguageRepository<TContext> where TContext : IBaseContext
    {
        public LanguageRepository(TContext unit) : base(unit)
        {

        }

    }
}
