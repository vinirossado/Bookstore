using Book.Domain;
using Book.Infra.CrossCutting.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.CrossCutting.Map;

public class PublisherMap : EntityTypeConfiguration<Publisher>
{
    public override void Map(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("publishers");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name");
    }
}