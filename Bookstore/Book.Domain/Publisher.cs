namespace Book.Domain;

public record Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual IEnumerable<Book> Books { get; set; }
};