using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Training.Domain.Interfaces.Base;
using Training.Infrastructure.DataContext;

namespace Training.Infrastructure.Repositories.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T>, IDisposable
        where T : class
    {

        public readonly TrainingModuleContext Context;

        private readonly DbSet<T> _entitiySet;

        private bool _isDisposed;


        public GenericRepository(TrainingModuleContext context)
        {
            Context = context;
            _entitiySet = Context.Set<T>();
            _isDisposed = false;
        }



        public virtual void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Context.Add(entity);


            }
            catch (Exception dbEx)
            {
                throw new Exception("FailSave", dbEx);
            }

        }

        public virtual void Update(T entity)
        {

            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Context?.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;

            }
            catch (Exception dbEx)
            {
                throw new Exception("FailUpdate", dbEx);
            }
        }
        public void Delete(T entity)
        {

            Context.Remove(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities) => Context.AddRange(entities);
        public virtual void UpdateRange(IEnumerable<T> entities) => Context.UpdateRange(entities);
        public virtual void DeleteRange(IEnumerable<T> entities) => Context.RemoveRange(entities);



        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                await Context.AddAsync(entity, cancellationToken);

            }
            catch (Exception dbEx)
            {
                throw new Exception("FailAddAsync", dbEx);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await Context.AddRangeAsync(entities, cancellationToken);
        }

        public T? FindById(object guid)
        {
            return _entitiySet.Find(guid);
        }

        public async Task<T> FindByIdAsync(string guid)
        {
            return await _entitiySet.FindAsync(guid);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _entitiySet.Where(expression).ToList();
        }



        public IEnumerable<T> GetAll()
        {
            return _entitiySet.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _entitiySet.Where(predicate).ToList();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entitiySet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitiySet.Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);
        }


        public void Dispose()
        {
            Context?.Dispose();
            _isDisposed = true;
        }


    }
}
