namespace Book.Domain;

public record BookGenre
{
    public int GenreId { get; set; }
    public string BookId { get; set; }

    public virtual IList<Book> Books { get; set; }
    public virtual IList<Genre> Genres { get; set; }
};