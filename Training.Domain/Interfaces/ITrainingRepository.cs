using Training.Domain.Interfaces.Base;

namespace Training.Domain.Interfaces
{
    public interface ITrainingRepository : IGenericRepository<Training.Domain.Entities.Training>
    {
        Task<IEnumerable<Training.Domain.Entities.Training>> GetAllTraining();
    }
}
