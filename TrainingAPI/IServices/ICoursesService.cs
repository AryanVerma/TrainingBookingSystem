namespace TrainingAPI.IServices
{
    public interface ICoursesService
    {
        Task<IReadOnlyList<Training.Domain.Entities.Course>> GetAll();
        Task AddCourse(Training.Domain.Entities.Course course);
    }
}
