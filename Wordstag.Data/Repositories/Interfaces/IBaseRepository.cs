using System.Linq.Expressions;
using Wordstag.Data.Contexts;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T, TContext> where T : class where TContext : IBaseContext
    {
        T GetById(object id);

        IEnumerable<T> Get(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                int skip = 0,
                int take = 10);

        IEnumerable<T> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        int Count();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool eager = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool eager = false);

        IQueryable<T> FindWithChilds(Expression<Func<T, bool>> predicate, bool eager = false);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        void RemoveRange(IEnumerable<T> entities);

        void Remove(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);

        Task<T> GetAsync(string id);

        Task<T> GetAsync(Guid id);

        Task<T> GetAsync(int id);

        IQueryable<T> GetAllAsQuerable();

        IQueryable<T> Query(bool eager = false);

        IQueryable<T> GetAllAsQuerable(string navigationPropertyInclude1, string navigationPropertyInclude2);

        Task AddAsync(T entity);

        Task AttachUpdateEntity(T entity);
    }
}