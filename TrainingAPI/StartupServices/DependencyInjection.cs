using Microsoft.EntityFrameworkCore;
using Training.Domain.Interfaces;
using Training.Infrastructure.DataContext;
using Training.Infrastructure.Repositories;
using Training.Infrastructure.UnitOfWork;
using TrainingAPI.Helpers;
using TrainingAPI.IServices;
using TrainingAPI.Services;

namespace TrainingAPI.StartupSpecifications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDataContext), typeof(TrainingModuleContext));
            services.AddDbContext<TrainingModuleContext>(opt => opt.UseSqlServer(ConfigurationHelper.TrainingModuleConnection));

            return services;
        }
    }
}