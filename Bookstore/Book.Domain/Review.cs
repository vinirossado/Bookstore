namespace Domain;

public class Review
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string BookId { get; set; }
    public int Rate { get; set; }
    public DateTime Date { get; set; }

    // public virtual Customer Customer { get; set; }
    public virtual Book Book { get; set; }
};