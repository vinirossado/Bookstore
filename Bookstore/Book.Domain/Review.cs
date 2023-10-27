namespace Book.Domain;

public record Review
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int CustomerId { get; set; }
    public int Rate { get; set; }
    public DateTime Date { get; set; }
};