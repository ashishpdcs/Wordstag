using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class DocumentRepository<TContext> : BaseRepository<Document, TContext>, IDocumentRepository<TContext> where TContext : IBaseContext
    {
        public DocumentRepository(TContext unit) : base(unit)
        {

        }

    }
}
