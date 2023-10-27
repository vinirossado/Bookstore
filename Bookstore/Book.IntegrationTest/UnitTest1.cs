using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Book.IntegrationTest;

public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/book");

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }

    [Fact]
    public async Task GetAll_Books()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/book");

        response.EnsureSuccessStatusCode();

        var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
        Assert.Equal(1653, books.Count());
    }
}