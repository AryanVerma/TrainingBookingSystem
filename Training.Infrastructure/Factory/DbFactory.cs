using Microsoft.EntityFrameworkCore;

namespace Training.Infrastructure.Factory
{
    public class DatabaseFactory<T> where T : DbContext, new()
    {
        private T dbContext;
        public T Init()
        {
            return dbContext ?? (dbContext = new T());
        }
    }
    public interface IDatabaseFactory<T> where T : DbContext
    {
        T Init();
    }

}
