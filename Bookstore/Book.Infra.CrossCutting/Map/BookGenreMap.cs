using Book.Infra.CrossCutting.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.CrossCutting.Map;

public class BookGenreMap : EntityTypeConfiguration<BookGenre>
{
    public override void Map(EntityTypeBuilder<BookGenre> builder)
    {
        builder.ToTable("books_genres");

        builder.HasKey(x => new { x.BookId, x.GenreId });

        builder.Property(x => x.BookId).HasColumnName("book_id").IsRequired();
        builder.Property(x => x.GenreId).HasColumnName("genre_id").IsRequired();
    }
}