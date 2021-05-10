using App.Application.Apartamentos.Services;
using App.Domain.Apartamentos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Ioc.Injectors
{
    public static class ApartamentoInjector
    {
        public static void AddApartamentoInjector(this IServiceCollection services)
        {
            services.AddScoped<IApartamentoService, ApartamentoService>();
        }
    }
}