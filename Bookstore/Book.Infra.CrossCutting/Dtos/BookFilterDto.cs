namespace Book.Infra.CrossCutting.Dtos;

public record BookFilterDto
{
    public string? AuthorName { get; set; }
    public string? Title { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
}