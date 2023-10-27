using Microsoft.EntityFrameworkCore;

namespace Book.Infra.CrossCutting.Extensions;

public static class ModelBuilderExtensions
{
    public static void AddConfiguration<TEntity>(this ModelBuilder builder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
    {
        configuration.Map(builder.Entity<TEntity>());
    }
}