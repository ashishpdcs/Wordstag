using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IDocumentRepository<TContext> : IBaseRepository<Document, TContext> where TContext : IBaseContext
    {

    }
}
