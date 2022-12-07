using Microsoft.EntityFrameworkCore;
using Training.Domain.Interfaces;
using Training.Infrastructure.DataContext;
using Training.Infrastructure.Repositories.Base;

namespace Training.Infrastructure.Repositories
{
    public class TrainingRepository : GenericRepository<Domain.Entities.Training>, ITrainingRepository
    {
        public TrainingRepository(TrainingModuleContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Domain.Entities.Training>> GetAllTraining()
        {
            return await Context.Training.ToListAsync();
        }
    }
}
