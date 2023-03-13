using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Infrastructure;

namespace Wordstag.Data.Repositories
{
    public class BaseRepository<T, TContext> : IBaseRepository<T, TContext> where T : class where TContext : IBaseContext
    {
        private readonly TContext Context;
        protected BaseRepository(TContext context)
        {
            this.Context = context;
        }

        public void Add(T entity)
        {
            var dbSet = this.Context.Set<T>();
            dbSet.Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            var dbSet = this.Context.Set<T>();
            await dbSet.AddAsync(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int skip = 0, int take = 10)
        {
            IQueryable<T> query = this.Context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            return orderBy != null ? orderBy(query).Skip(skip).Take(take) : query;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = this.Context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            return orderBy != null ? orderBy(query) : query;
        }

        public T GetById(object id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public T GetById(Guid id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public int Count()
        {
            return this.Context.Set<T>().Count();
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            this.Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> GetAllAsQuerable(string navigationPropertyInclude1, string navigationPropertyInclude2)
        {
            return this.Context.Set<T>().Include(navigationPropertyInclude1).Include(navigationPropertyInclude2).AsQueryable();
        }

        public virtual IQueryable<T> Query(bool eager = false)
        {
            var query = this.Context.Set<T>().AsQueryable();
            if (eager)
            {
                foreach (var property in this.Context.Model.FindEntityType(typeof(T)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }

        public virtual IQueryable<T> GetAllAsQuerable()
        {
            return this.Context.Set<T>().AsQueryable();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await this.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await this.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetAsync(string id)
        {
            return await this.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await this.Context.Set<T>().Where(predicate).ToListAsync();
            }
            else
            {
                return await this.Context.Set<T>().ToListAsync();
            }
        }


        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            var dbSet = this.Context.Set<T>();
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual void Remove(T entity)
        {
            var dbSet = this.Context.Set<T>();
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            var dbSet = this.Context.Set<T>();
            dbSet.RemoveRange(entities);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = this.Context.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.CountAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var dbSet = this.Context.Set<T>();
            return await dbSet.AnyAsync(predicate);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool eager = false)
        {
            var dbSet = this.Context.Set<T>();
            return Query(eager).Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> FindWithChilds(Expression<Func<T, bool>> predicate, bool eager = false)
        {
            var dbSet = this.Context.Set<T>();
            var asQuery = Query(eager).Where(predicate).AsQueryable();

            Func<IQueryable<T>, IQueryable<T>> includeFunc = f => f;
            foreach (var prop in typeof(T).GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(IncludeAttribute))))
            {
                Func<IQueryable<T>, IQueryable<T>> chainedIncludeFunc = f => f.Include(prop.Name);
                includeFunc = Compose(includeFunc, chainedIncludeFunc);
            }
            return includeFunc(asQuery);
        }

        private static Func<T, T> Compose<T>(Func<T, T> innerFunc, Func<T, T> outerFunc)
        {
            return arg => outerFunc(innerFunc(arg));
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool eager = false)
        {
            return await Query(eager).FirstOrDefaultAsync(predicate);
        }

        //https://github.com/thepirat000/Audit.NET/issues/53
        public async Task AttachUpdateEntity(T entity)
        {
            var entry = this.Context.Set<T>().Attach(entity); // Attach to the DbContext
            var updated = entry.CurrentValues.Clone();
            entry.Reload();
            entry.CurrentValues.SetValues(updated);
            entry.State = EntityState.Modified;
            //await this.Context.SaveChangesAsync();
        }
    }
}
