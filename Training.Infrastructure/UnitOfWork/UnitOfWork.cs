using Microsoft.EntityFrameworkCore;
using Training.Common.DTO;
using Training.Domain.Interfaces.Base;
using Training.Infrastructure.DataContext;
using Training.Infrastructure.Repositories.Base;

namespace Training.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Here TContext is nothing but your DBContext class
        //In our example it is EmployeeDBContext class

        private readonly IDataContext Context;

        private Dictionary<string, object> _repositories;
        public UnitOfWork(IDataContext dataContext)
        {

            Context = dataContext;
            _repositories = new Dictionary<string, object>();
        }
        //private readonly IDatabaseFactory<T> dbFactory;
        //private T dbContext;

        //protected T Context
        //{
        //    get { return dbContext ?? (dbContext = dbFactory.Init()); }
        //}

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return _repositories[type] as GenericRepository<TEntity>;
            }

            if (!_repositories.ContainsKey(type))
            {
                object? respositoryInstance = Activator.CreateInstance(typeof(IGenericRepository<TEntity>).MakeGenericType(typeof(TEntity)), Context);
                _repositories.Add(type, respositoryInstance);
            }
            return (GenericRepository<TEntity>)_repositories[type];
        }
        public async Task<AppResponse> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveAppResponseAsync(cancellationToken);
        }

        #region  DisposeSupport
        private void Dispose(bool disposing)
        {

            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                }

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion

    }
}
