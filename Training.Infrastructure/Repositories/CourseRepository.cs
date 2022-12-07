using Microsoft.EntityFrameworkCore;
using Training.Domain.Interfaces;
using Training.Infrastructure.DataContext;
using Training.Infrastructure.Repositories.Base;

namespace Training.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Training.Domain.Entities.Course>, ICourseRepository
    {
        public CourseRepository(TrainingModuleContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Training.Domain.Entities.Course>> GetAllCourses()
        {
            return await Context.Course.ToListAsync();
        }
    }
}
