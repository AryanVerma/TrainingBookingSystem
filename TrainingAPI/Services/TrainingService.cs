using Autofac;
using Autofac.Core;
using Training.Infrastructure.UnitOfWork;
using TrainingAPI.IServices;

namespace TrainingAPI.Services
{
    public class TrainingService : BaseService, ITrainingService
    {

        private IUnitOfWork _unitOfWork => ComponentContext.Resolve<IUnitOfWork>();

        public IComponentContext Container => throw new NotImplementedException();

        // private readonly IUnitOfWork _unitOfWork;
        public TrainingService(ICommonServices componentContext) : base(componentContext)
        {
            //_unitOfWork = unitOfWork;
            //this.componentContext = componentContext;
        }
        public async Task<IReadOnlyList<Training.Domain.Entities.Training>> GetAll()
        {

            var data = await _unitOfWork.GetRepository<Training.Domain.Entities.Training>().GetAllAsync();
            return data;
        }

        public async Task AddTraining(Training.Domain.Entities.Training training)
        {
            await _unitOfWork.GetRepository<Training.Domain.Entities.Training>().AddAsync(training);
            _ = await _unitOfWork.SaveAsync();
        }


    }
}
