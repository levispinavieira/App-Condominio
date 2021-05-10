using App.Domain.Apartamentos.Entities;
using App.Domain.Blocos.Entities;
using App.Domain.Condominios.Entities;
using App.Domain.Pessoas.Entities;
using App.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Infra.Data.Contexts
{
    public class DbAppContext : IdentityDbContext, IDbAppContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }

        public bool HasChanges => ChangeTracker.HasChanges();
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigureDbContext(optionsBuilder);
        }

        protected virtual void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=192.168.99.100;Port=5432;Pooling=true;Database=APP_CONDOMINIO;User Id=postgres;Password=postgres"
                );
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();

                base.OnConfiguring(optionsBuilder);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Parent On Model Creating
            base.OnModelCreating(builder);

            // ApplyAllMappersExtension
            builder.AddConfigureModels();
        }
    }
}