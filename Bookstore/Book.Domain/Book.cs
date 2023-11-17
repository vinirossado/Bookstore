namespace Domain;

public sealed class Book
{
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Edition { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal Price { get; set; }
    public Author Author { get; set; }

    public Publisher Publisher { get; set; }
    // public virtual IEnumerable<Review> Reviews { get; set; }

    public List<Genre> Genres { get; } = new();
    public List<BookGenre> BookGenres { get; } = new();

    private DateTime _publicationDate;

    public DateTime PublicationDate
    {
        get { return _publicationDate; }
        set { _publicationDate = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
    }
};