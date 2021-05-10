using App.Application.Blocos.Services;
using App.Domain.Blocos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Ioc.Injectors
{
    public static class BlocoInjector
    {
        public static void AddBlocoInjector(this IServiceCollection services)
        {
            services.AddScoped<IBlocoService, BlocoService>();
        }
    }
}