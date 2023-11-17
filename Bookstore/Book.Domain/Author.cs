namespace Domain;

public class Author
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? CompanyName { get; set; }
    public virtual IEnumerable<Book> Books { get; set; }
};