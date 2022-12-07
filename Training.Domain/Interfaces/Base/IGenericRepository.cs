using System.Linq.Expressions;

namespace Training.Domain.Interfaces.Base
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);


        T FindById(object guid);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);


        Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> FindByIdAsync(string guid);
        Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));


    }
}
