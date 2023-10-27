using Book.Infra.CrossCutting.Extensions;
using Book.Infra.CrossCutting.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Book.Infra.CrossCutting.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Domain.Book> Book { get; set; }

    protected readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseNpgsql(LaunchEnvironment.DbConnectionString);
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Pooling=true;Database=Bookstore;User Id=default;Password=default;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.AddConfiguration(new BookMap());
        builder.AddConfiguration(new AuthorMap());
        builder.AddConfiguration(new GenreMap());
        builder.AddConfiguration(new PublisherMap());
        builder.AddConfiguration(new ReviewMap());
    }
}