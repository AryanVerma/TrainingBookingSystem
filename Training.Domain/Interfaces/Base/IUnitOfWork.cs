using Training.Common.DTO;
using Training.Domain.Interfaces.Base;

namespace Training.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<AppResponse> SaveAsync(CancellationToken cancellationToken = default);
    }
}
