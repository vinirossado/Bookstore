using Book.Domain;
using Book.Infra.CrossCutting.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.CrossCutting.Map;

public class AuthorMap : EntityTypeConfiguration<Author>
{
    public override void Map(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("authors");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.FirstName).HasColumnName("first_name");
        builder.Property(x => x.SecondName).HasColumnName("second_name");
        builder.Property(x => x.CompanyName).HasColumnName("company_name");
        
    }
};