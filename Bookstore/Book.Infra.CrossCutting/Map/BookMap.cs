using Book.Infra.CrossCutting.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.CrossCutting.Map;

public class BookMap : EntityTypeConfiguration<Domain.Book>
{
    public override void Map(EntityTypeBuilder<Domain.Book> builder)
    {
        builder.ToTable("books");
        builder.HasKey(x => x.Isbn);
        
        builder.Property(x => x.Isbn).HasColumnName("isbn").IsRequired();
        builder.Property(x => x.Title).HasColumnName("title");
        builder.Property(x => x.PublicationDate).HasColumnName("publication_date");
        builder.Property(x => x.Edition).HasColumnName("edition");
        builder.Property(x => x.AvailableQuantity).HasColumnName("available_quantity");
        builder.Property(x => x.Price).HasColumnName("price");
        builder.Property(x => x.AuthorId).HasColumnName("author");
        builder.Property(x => x.PublisherId).HasColumnName("publisher");
        
        builder.HasOne(x => x.Author).WithMany(e => e.Books).HasForeignKey(x => x.AuthorId);
        builder.HasOne(x => x.Publisher).WithMany(e => e.Books).HasForeignKey(x => x.PublisherId);
        
    }
}