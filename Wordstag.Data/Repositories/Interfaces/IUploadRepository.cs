using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Upload;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IUploadRepository<TContext> : IBaseRepository<UploadTbl, TContext> where TContext : IBaseContext
    {
    

    }
}
