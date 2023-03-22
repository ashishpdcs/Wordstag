using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Upload;

namespace Wordstag.Data.Repositories
{
    public class UploadRepository<TContext> : BaseRepository<UploadTbl, TContext>, IUploadRepository<TContext> where TContext : IBaseContext
    {
        public UploadRepository(TContext unit) : base(unit)
        {

        }

    }
}
