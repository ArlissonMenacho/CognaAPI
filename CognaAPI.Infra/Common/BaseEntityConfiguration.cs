using CognaAPI.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognaAPI.Infra.Common
{
    public abstract class BaseEntityConfigutration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(p => p.Id);
            builder.Property(c => c.Criado)
                .IsRequired();
            builder.Property(c => c.UltimaModificacao)
                .IsRequired(false);
        }
    }
}
