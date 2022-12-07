using Microsoft.EntityFrameworkCore;
using Training.Common.DTO;

namespace Training.Infrastructure.DataContext
{
    public interface IDataContext : IDisposable
    {
        DbSet<Domain.Entities.Training> Training { get; set; }
        DbSet<Domain.Entities.Course> Course
        {
            get; set;
        }
        DbSet<Domain.Entities.Region> Region
        {
            get; set;
        }
        Task TraingingModuleBeginTransactionAsync(CancellationToken cancellationToken = default);
        Task TraingingModuleCommitTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> TraingingModuleCompleteAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
        void Commit();
        void Rollback();

        Task<AppResponse> SaveAppResponseAsync(CancellationToken cancellationToken = default);
        Task<AppResponse> UpdateBulkAppResponseAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;
        Task<AppResponse> DeleteBulkAppResponseAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;
        Task<AppResponse> AddBulkAppResponseAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;
        void RejectChanges();
        AppResponse Save();
    }
}

