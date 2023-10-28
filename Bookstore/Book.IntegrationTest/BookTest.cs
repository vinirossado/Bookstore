using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Book.IntegrationTest;

public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll_EndpointReturnsJsonContentType()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/book");

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task GetAll_EndpointReturnsCorrectItemCount()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/book");

        response.EnsureSuccessStatusCode(); 
        var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
        if (books != null) Assert.Equal(1653, books.Count());
    }

    [Fact]
    public async Task GetBookByIsbn_EndpointReturnsCorrectItem()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/book/978-62-82077-46-4");

        response.EnsureSuccessStatusCode();
        var book = await response.Content.ReadFromJsonAsync<Domain.Book>();
        Assert.Equal("978-62-82077-46-4", book?.Isbn);
    }

    [Fact]
    public async Task GetBooksByFilter_ReturnsBadRequestWhenThereAreNoFilters()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/book/filter");

        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        Assert.Equal("[\"Needs to have at least one property with value\"]", content);
    }
}
