using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Ioc.Configurations
{
    public static class AppInfraIoCConfiguration
    {
        public static void AddCoreInfraIoCConfiguration(this IServiceCollection services)
        {
            // Add Core Injectors
            services.AddAppInjectorServices();
        }
    }
}