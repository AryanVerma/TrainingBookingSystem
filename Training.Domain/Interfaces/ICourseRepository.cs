using Training.Domain.Entities;
using Training.Domain.Interfaces.Base;

namespace Training.Domain.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Training.Domain.Entities.Course>
    {
        Task<IEnumerable<Training.Domain.Entities.Course>> GetAllCourses();
    }
}
