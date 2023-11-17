using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.CrossCutting.Extensions;

public abstract class EntityTypeConfiguration<TEntity> where TEntity: class
{
    public abstract void Map(EntityTypeBuilder<TEntity> builder);
}