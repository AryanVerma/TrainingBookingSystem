using Training.Domain.Entities;
using Training.Domain.Interfaces.Base;

namespace Training.Domain.Interfaces
{
    public interface IRegionRepository : IGenericRepository<Training.Domain.Entities.Region>
    {
        Task<IEnumerable<Training.Domain.Entities.Region>> GetAllRegion();
    }
}
