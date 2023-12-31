using Book.Infra.CrossCutting.Dtos;
using Book.Repository.Interfaces;
using Book.Service.Implements;
using DotNet.Testcontainers.Builders;
using Microsoft.Extensions.Caching.Memory;

namespace Book.Service.Interfaces;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMemoryCache _memoryCache;

    public BookService(IBookRepository repository, IMemoryCache memoryCache)
    {
        _repository = repository;
        _memoryCache = memoryCache;
 
    }

    public async Task<IEnumerable<Domain.Book>> GetAll()
    {
        IEnumerable<Domain.Book> output = new List<Domain.Book>();
        const string cacheKey = "all_books";

        if (_memoryCache.TryGetValue(cacheKey, out output)) return output;
        var books = await _repository.GetAll();

        output = books;

        var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
        _memoryCache.Set(cacheKey, output, cacheOptions);

        return output;
    }

    public Domain.Book? GetBookByIsbnCompiled(string isbn)
    {
        return _repository.GetBookByIsbnCompiled(isbn);
    }

    public async Task<IEnumerable<Domain.Book>> GetBooksByFilter(BookFilterDto dto)
    {
        var books = await _repository.GetBooksByFilter(dto);

        var bannedAuthors = books.Where(x =>
            (x.Author.FirstName?.Contains("ski") ?? false) ||
            (x.Author.SecondName?.Contains("ski") ?? false));

        books = books.Except(bannedAuthors);

        return books;
    }

    private async Task<IEnumerable<Domain.Book>> ReturnsEmptyListWhenAuthorNameEndsWithSki()
    {
        return await Task.FromResult(Enumerable.Empty<Domain.Book>());
    }
}