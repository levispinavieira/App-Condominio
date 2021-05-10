using App.Application.Pessoas.Services;
using App.Domain.Pessoas.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.Ioc.Injectors
{
    public static class PessoaInjector
    {
        public static void AddPessoaInjector(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
        }
    }
}