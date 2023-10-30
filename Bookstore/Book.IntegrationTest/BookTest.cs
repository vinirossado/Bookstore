using System.Net.Http.Json;
using Book.Repository.Interfaces;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Book.IntegrationTest;

public class IntegrationTest : BaseIntegrationTest
{
    private readonly IBookRepository _bookRepository;

    public IntegrationTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
        _bookRepository = _scope.ServiceProvider.GetRequiredService<IBookRepository>();
    }

    [Fact]
    public async Task GetAll_EndpointReturnsCorrectItemCount()
    {
        var book = new Domain.Book {
            Title = "Test",
            Isbn = "2-945-90048-3",
            Author = new Author
            {
                FirstName = "Test",
                SecondName = "Test"
            },
            AvailableQuantity = 1,
            Edition = 1,
            Price = 1,
            PublicationDate = DateTime.Now,
            Publisher = new Publisher
            {
                Name = "Test"
            }
        };

        await DbContext.Book.AddAsync(book);
        await DbContext.SaveChangesAsync();

        var response = await _client.GetAsync("/api/book");

        response.EnsureSuccessStatusCode();

        var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();

        if (books != null)
            Assert.Single(books);
    }

    // [Fact]
    // public async Task GetBookByIsbn_EndpointReturnsCorrectItem()
    // {
    //     var response = await _client.GetAsync("/api/book/978-62-82077-46-4");
    //
    //     response.EnsureSuccessStatusCode();
    //     var book = await response.Content.ReadFromJsonAsync<Domain.Book>();
    //     Assert.Equal("978-62-82077-46-4", book?.Isbn);
    // }
    //
    // [Fact]
    // public async Task GetBooksByFilter_ReturnsBadRequestWhenThereAreNoFilters()
    // {
    //     var response = await _client.GetAsync("/api/book/filter");
    //
    //     var content = await response.Content.ReadAsStringAsync();
    //
    //     Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    //
    //     Assert.Equal("[\"Needs to have at least one property with value\"]", content);
    // }
    //
    // [Fact]
    // public async Task GetBooksByFilter_FilterByTitle_ReturnsMatchingBooks()
    // {
    //     var response = await _client.GetAsync("/api/book/filter?Title=Kontratak");
    //
    //     var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
    //
    //     var book = books.First();
    //     Assert.Equal("978-03-19379-22-4", book.Isbn);
    //     Assert.Equal("Kontratak", book.Title);
    //     Assert.Equal("1906-04-02", book.PublicationDate.ToString("yyyy-MM-dd"));
    //     Assert.Equal(1, book.Edition);
    //     Assert.Equal(59, book.AvailableQuantity);
    //     Assert.Equal((decimal)27.20, book.Price);
    //     Assert.Equal("Maciek", book.Author.FirstName);
    // }
    //
    // [Fact]
    // public async Task GetBooksByFilter_FilterByAuthor_ReturnsMatchingBooks()
    // {
    //     var response = await _client.GetAsync("/api/book/filter?AuthorName=Bartłomiej");
    //
    //     var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
    //
    //     Assert.Equal("Bartłomiej", books.First().Author.FirstName);
    //     Assert.Equal(17, books.Count());
    // }
    //
    // [Fact]
    // public async Task GetBooksByFilter_FilterByAuthorSecondName_ReturnsMatchingBooks()
    // {
    //     var response = await _client.GetAsync("/api/book/filter?AuthorName=Cebulska");
    //
    //     var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
    //
    //     Assert.Equal("Cebulska", books.First().Author.SecondName);
    //     Assert.Equal(9, books.Count());
    // }
    //
    // [Fact]
    // public async Task GetBooksByFilter_FilterByAuthorSecondName_ReturnsEmptyListWhenAuthorNameEndsWithSki()
    // {
    //     var response = await _client.GetAsync("/api/book/filter?AuthorName=Wiśniewski");
    //
    //     var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
    //
    //     Assert.Equal(0, books.Count());
    // }
    //
    // [Fact]
    // public async Task GetBooksByFilter_FilterByMinPriceIsZero_ReturnsMatchingBooks()
    // {
    //     var response = await _client.GetAsync("/api/book/filter?MinPrice=0");
    //
    //     var books = await response.Content.ReadFromJsonAsync<List<Domain.Book>>();
    //
    //     Assert.Equal(1407, books.Count());
    // }
}