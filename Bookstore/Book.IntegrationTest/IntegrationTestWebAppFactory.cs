using Book.Infra.CrossCutting.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Book.IntegrationTest;

public class IntegrationTestWebAppFactory
    : WebApplicationFactory<Program>,
        IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .WithDatabase("Bookstore")
        .WithUsername("default")
        .WithPassword("default")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptorType =
                typeof(DbContextOptions<ApplicationDbContext>);

            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == descriptorType);

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(_postgres.GetConnectionString()));
        });
    }

    // protected override void ConfigureWebHost(IWebHostBuilder builder)
    // {
    //     builder.ConfigureTestServices(services =>
    //     {
    //         var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
    //         if (descriptor != null) services.Remove(descriptor);
    //         
    //         services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(_postgres.GetConnectionString()); });
    //         
    //         var serviceProvider = services.BuildServiceProvider();
    //
    //         using var scope = serviceProvider.CreateScope();
    //         var scopedServices = scope.ServiceProvider;
    //         var context = scopedServices.GetRequiredService<ApplicationDbContext>();
    //         context.Database.EnsureCreated();
    //     });
    // }

    public string GetConnectionString() => _postgres.GetConnectionString();
    public Task InitializeAsync() => _postgres.StartAsync();
    public new Task DisposeAsync() => _postgres.StopAsync();
}