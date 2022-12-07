using Autofac;

namespace TrainingAPI.Services
{
    public interface ICommonServices
    {
        IComponentContext Container
        {
            get;
        }
    }
    public static class ICommonServicesExtensions
    {
        public static TService Resolve<TService>(this ICommonServices services)
        {
            return services.Container.Resolve<TService>();
        }
    }
    public class BaseService
    {
        public ICommonServices ComponentContext;
        public BaseService(ICommonServices componentContext)
        {
            this.ComponentContext = componentContext;
        }
    }
}
