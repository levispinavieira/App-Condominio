using App.Application.Condominios.Services;
using App.Domain.Condominios.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Ioc.Injectors
{
    public static class CondominioInjector
    {
        public static void AddCondominioInjector(this IServiceCollection services)
        {
            services.AddScoped<ICondominioService, CondominioService>();
        }
    }
}