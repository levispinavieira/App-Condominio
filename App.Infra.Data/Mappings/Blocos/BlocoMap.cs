using App.Domain.Blocos.Entities;
using App.Infra.Data.Mappings.Abstractions;
using App.Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings.Blocos
{
    public class BlocoMap: EntityBaseMap<Bloco>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Bloco> builder)
        {
            builder.ToTable(nameof(Bloco));

            builder
                .Property(e => e.Nome)
                .HasColumnType(TipoDados.String)
                .IsRequired();
            
            builder
                .HasOne(p => p.Condominio)
                .WithMany(p => p.Blocos)
                .HasForeignKey(m => m.CondominioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}