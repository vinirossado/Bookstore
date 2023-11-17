namespace Domain;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual List<Book> Books { get; } = new();
    public virtual List<BookGenre> BookGenres { get; } = new();
};