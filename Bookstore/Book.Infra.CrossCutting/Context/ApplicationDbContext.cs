using Book.Infra.CrossCutting.Extensions;
using Book.Infra.CrossCutting.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Book.Infra.CrossCutting.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Domain.Author> Author { get; set; }
    public DbSet<Domain.Book> Book { get; set; }
    // public DbSet<Domain.BookGenre> BookGenre { get; set; }
    public DbSet<Domain.Genre> Genre { get; set; }
    public DbSet<Domain.Publisher> Publisher { get; set; }
    public DbSet<Domain.Review> Review { get; set; }

    protected readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.AddConfiguration(new BookMap());
        builder.AddConfiguration(new AuthorMap());
        builder.AddConfiguration(new GenreMap());
        // builder.AddConfiguration(new BookGenreMap());
        builder.AddConfiguration(new PublisherMap());
        builder.AddConfiguration(new ReviewMap());
    }
}