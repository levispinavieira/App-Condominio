using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings.Abstractions
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T: class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureMap(builder);
        }

        protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);
    }
}