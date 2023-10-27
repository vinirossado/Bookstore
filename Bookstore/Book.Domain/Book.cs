using System.Text.Json.Serialization;

namespace Book.Domain;

public record Book
{
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Edition { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal Price { get; set; }

    public virtual Author Author { get; set; }
    public virtual Publisher Publisher { get; set; }
};