using Autofac;
using Training.Domain.Interfaces;
using Training.Infrastructure.UnitOfWork;
using TrainingAPI.IServices;

namespace TrainingAPI.Services
{
    public class CoursesService : BaseService, ICoursesService
    {
        private IUnitOfWork _unitOfWork => ComponentContext.Resolve<IUnitOfWork>();
        public CoursesService(ICommonServices componentContext) : base(componentContext)
        {
            //_unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Training.Domain.Entities.Course>> GetAll()
        {
            var data = await _unitOfWork.GetRepository<Training.Domain.Entities.Course>().GetAllAsync();
            return data;
        }

        public async Task AddCourse(Training.Domain.Entities.Course course)
        {
            await _unitOfWork.GetRepository<Training.Domain.Entities.Course>().AddAsync(course);
            _ = await _unitOfWork.SaveAsync();
        }
    }
}
