using App.Domain.Abstractions.Entities;
using App.Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings.Abstractions
{
    public abstract class EntityBaseMap<T> : BaseMap<T> where T : Entity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(m => m.CadastradoEm)
                .HasColumnType(TipoDados.DateTime)
                .IsRequired();

            builder.Property(m => m.AtualizadoEm)
                .HasColumnType(TipoDados.DateTime)
                .IsRequired();

            builder.Property(m => m.DeletadoEm)
                .HasColumnType(TipoDados.DateTime);

            builder.Property(m => m.Ativo)
                .HasColumnType(TipoDados.Boolean)
                .IsRequired();
            
            builder.HasQueryFilter(p => p.Ativo);
        }
    }
}
