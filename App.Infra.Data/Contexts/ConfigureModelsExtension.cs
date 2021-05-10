using App.Infra.Data.Mappings.Apartamentos;
using App.Infra.Data.Mappings.Blocos;
using App.Infra.Data.Mappings.Condominios;
using App.Infra.Data.Mappings.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Contexts
{
    public static class ConfigureModelsExtension
    {
        public static void AddConfigureModels(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApartamentoMap());
            builder.ApplyConfiguration(new BlocoMap());
            builder.ApplyConfiguration(new CondominioMap());
            builder.ApplyConfiguration(new PessoaMap());
        }
    }
}