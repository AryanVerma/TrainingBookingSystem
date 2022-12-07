namespace TrainingAPI.IServices
{
    public interface ITrainingService
    {
        Task<IReadOnlyList<Training.Domain.Entities.Training>> GetAll();
        Task AddTraining(Training.Domain.Entities.Training training);
    }
}
