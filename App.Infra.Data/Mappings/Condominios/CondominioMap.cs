using App.Domain.Condominios.Entities;
using App.Infra.Data.Mappings.Abstractions;
using App.Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings.Condominios
{
    public class CondominioMap: EntityBaseMap<Condominio>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Condominio> builder)
        {
            builder.ToTable(nameof(Condominio));

            builder
                .Property(e => e.Nome)
                .HasColumnType(TipoDados.String)
                .IsRequired();

            builder
                .Property(e => e.Telefone)
                .HasColumnType(TipoDados.String);

            builder
                .Property(e => e.EmailSindico)
                .HasColumnType(TipoDados.String);
        }
    }
}