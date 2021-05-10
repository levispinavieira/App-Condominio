using System;
using App.Infra.Ioc.Injectors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Ioc
{
    public static class AppInjector
    {
        public static void AddAppInjectorServices(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("App.Application");
            services.AddMediatR(config => config.AsScoped(), assembly);
            
            services.AddPessoaInjector();
            services.AddBlocoInjector();
            services.AddApartamentoInjector();
            services.AddCondominioInjector();
        }
    }
}