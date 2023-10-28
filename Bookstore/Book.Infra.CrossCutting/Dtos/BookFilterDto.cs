namespace Book.Infra.CrossCutting.Dtos;

public record BookFilterDto
{
    public string? Author { get; }
    public string? Title { get; }
    public decimal? MinPrice { get; }
    public decimal? MaxPrice { get; }
    public DateTime? MinDate { get; }
    public DateTime? MaxDate { get; }
}