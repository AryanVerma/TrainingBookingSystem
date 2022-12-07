using Microsoft.EntityFrameworkCore;
using Training.Domain.Interfaces;
using Training.Infrastructure.DataContext;
using Training.Infrastructure.Repositories.Base;

namespace Training.Infrastructure.Repositories
{
    public class RegionRepository : GenericRepository<Domain.Entities.Region>, IRegionRepository
    {
        public RegionRepository(TrainingModuleContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Domain.Entities.Region>> GetAllRegion()
        {
            return await Context.Region.ToListAsync();
        }

    }
}
