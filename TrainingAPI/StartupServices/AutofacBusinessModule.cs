using Autofac;
using Training.Domain.Interfaces;
using Training.Domain.Interfaces.Base;
using Training.Infrastructure.DataContext;
using Training.Infrastructure.Repositories;
using Training.Infrastructure.Repositories.Base;
using Training.Infrastructure.UnitOfWork;
using TrainingAPI.IServices;
using TrainingAPI.Services;

namespace TrainingAPI.StartupServices
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<BaseService>().As<IComponentContext>().InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

            builder.RegisterType<TrainingModuleContext>().As<IDataContext>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<RegionRepository>().As<IRegionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TrainingRepository>().As<ITrainingRepository>().InstancePerLifetimeScope();

            builder.RegisterType<TrainingService>().As<ITrainingService>().InstancePerLifetimeScope();


            base.Load(builder);

        }
    }
}
