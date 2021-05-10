using App.Domain.Apartamentos.Entities;
using App.Infra.Data.Mappings.Abstractions;
using App.Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings.Apartamentos
{
    public class ApartamentoMap: EntityBaseMap<Apartamento>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Apartamento> builder)
        {
            builder.ToTable(nameof(Apartamento));

            builder
                .Property(e => e.Numero)
                .HasColumnType(TipoDados.Integer)
                .IsRequired();

            builder
                .Property(e => e.Andar)
                .HasColumnType(TipoDados.Integer);
            
            builder
                .HasOne(p => p.Bloco)
                .WithMany(p => p.Apartamentos)
                .HasForeignKey(m => m.BlocoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}