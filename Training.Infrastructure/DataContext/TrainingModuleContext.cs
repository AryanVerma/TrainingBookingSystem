using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Training.Common.Common.Enum;
using Training.Common.Common.Extensions;
using Training.Common.DTO;

namespace Training.Infrastructure.DataContext
{
    public class TrainingModuleContext : DbContext, IDataContext
    {
        private IDbContextTransaction _transaction;
        public TrainingModuleContext(DbContextOptions<TrainingModuleContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Domain.Entities.Training> Training
        {
            get; set;
        }
        public DbSet<Domain.Entities.Course> Course
        {
            get; set;
        }
        public DbSet<Domain.Entities.Region> Region
        {
            get; set;
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public async Task TraingingModuleBeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task TraingingModuleCommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task<int> TraingingModuleCompleteAsync(CancellationToken cancellationToken = default)
        {
            var result = await SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<AppResponse> SaveAppResponseAsync(CancellationToken cancellationToken = default)
        {
            using (var t = await Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    await SaveChangesAsync();
                    await t.CommitAsync();
                    return new AppResponse().SetSaveSuccess(nameof(ResponseMessageEnums.Saved));
                }
                catch (Exception ex)
                {
                    await t.RollbackAsync();
                    return new AppResponse().SetFail(ex.Message);
                }
            }
        }
        public AppResponse Save()
        {
            using (var t = Database.BeginTransaction())
            {
                try
                {
                    SaveChanges();
                    t.Commit();
                    return new AppResponse().SetSaveSuccess(nameof(ResponseMessageEnums.Saved));
                }
                catch (Exception ex) { return new AppResponse().SetFail(ex.Message); }

            }

        }
        public void RejectChanges()
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry? entry in ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        public async Task<AppResponse> UpdateBulkAppResponseAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {

            using (var t = await Database.BeginTransactionAsync())
            {
                try
                {
                    await this.BulkUpdateAsync(entities.ToList(), new BulkConfig { BatchSize = 100 }, cancellationToken: cancellationToken);
                    await t.CommitAsync();
                    return new AppResponse().SetUpdateSuccess(nameof(ResponseMessageEnums.Updated));
                }
                catch (Exception ex)
                {
                    await t.RollbackAsync();
                    return new AppResponse().SetFail(ex.Message);
                }

            }


        }

        public async Task<AppResponse> DeleteBulkAppResponseAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {

            using (var t = await Database.BeginTransactionAsync())
            {
                try
                {
                    await this.BulkDeleteAsync(entities.ToList(), new BulkConfig { BatchSize = 100 }, cancellationToken: cancellationToken);
                    await t.CommitAsync();
                    return new AppResponse().SetUpdateSuccess(nameof(ResponseMessageEnums.Deleted));
                }
                catch (Exception ex)
                {
                    await t.RollbackAsync();
                    return new AppResponse().SetFail(ex.Message);
                }

            }


        }

        public async Task<AppResponse> AddBulkAppResponseAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {

            using (var t = await Database.BeginTransactionAsync())
            {
                try
                {
                    await this.BulkInsertAsync(entities.ToList(), new BulkConfig { BatchSize = 100 }, cancellationToken: cancellationToken);
                    await t.CommitAsync();
                    return new AppResponse().SetSaveSuccess(nameof(ResponseMessageEnums.Saved));
                }
                catch (Exception ex)
                {
                    await t.RollbackAsync();
                    return new AppResponse().SetFail(ex.Message);
                }

            }



        }
        //public override int SaveChanges()
        //{

        //    var modifiedEntries = ChangeTracker.Entries().Where(r => r.Entity is IAuditEntity
        //    && (r.State == EntityState.Added
        //    || r.State == EntityState.Modified));
        //    foreach (var item in modifiedEntries)
        //    {
        //        if (item.Entity is IAuditEntity entity)
        //        {
        //            string IdentityName = Thread.CurrentPrincipal.Identity.Name;
        //            DateTime now = DateTime.UtcNow;
        //            if (item.State == EntityState.Added)
        //            {

        //            }
        //            else
        //            {

        //            }
        //        }

        //    }
        //    return base.SaveChanges();
        //}
    }
}
