using App.Domain.Pessoas.Entities;
using App.Infra.Data.Mappings.Abstractions;
using App.Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings.Pessoas
{
    public class PessoaMap: EntityBaseMap<Pessoa>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(nameof(Pessoa));

            builder
                .Property(e => e.NomeCompleto)
                .HasColumnType(TipoDados.String)
                .IsRequired();

            builder
                .Property(e => e.Telefone)
                .HasColumnType(TipoDados.String);

            builder
                .Property(e => e.Cpf)
                .HasColumnType(TipoDados.String);
            
            builder
                .Property(e => e.DataNascimento)
                .HasColumnType(TipoDados.Date);
            
            builder
                .Property(e => e.Email)
                .HasColumnType(TipoDados.String);
            
            builder
                .HasOne(p => p.Apartamento)
                .WithMany(p => p.Pessoas)
                .HasForeignKey(m => m.ApartamentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}