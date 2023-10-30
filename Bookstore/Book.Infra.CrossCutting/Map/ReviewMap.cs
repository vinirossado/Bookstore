using Book.Infra.CrossCutting.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.CrossCutting.Map;

public class ReviewMap : EntityTypeConfiguration<Review>
{
    public override void Map(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.Date).HasColumnName("date");
        builder.Property(x => x.Rate).HasColumnName("review");
        builder.Property(x => x.BookId).HasColumnName("book_id");
        
        // builder.HasOne(x => x.Book).WithMany(x => x.Reviews).HasForeignKey(x => x.BookId);
    }
}