namespace Book.Domain;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual IEnumerable<Book> Books { get; set; }
};