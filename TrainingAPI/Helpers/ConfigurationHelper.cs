using Microsoft.Extensions.Options;

namespace TrainingAPI.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration config;
        public static void Init(IConfiguration configuration)
        {
            config = configuration;
        }
        public static string TrainingModuleConnection => config.GetValue<string>("ConnectionStrings:Connection");
    }
}
