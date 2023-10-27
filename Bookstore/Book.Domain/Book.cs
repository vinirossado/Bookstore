
namespace Book.Domain;

public class Book
{
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public DateTime PublicationDate { get; set; }
    public int Edition { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal Price { get; set; }

    public virtual Author Author { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual IEnumerable<Review> Reviews { get; set; }
};