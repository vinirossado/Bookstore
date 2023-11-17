using Book.Infra.CrossCutting.Context;
using Book.Infra.CrossCutting.Dtos;
using Book.Repository.CompiledQuery;
using Book.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Repository.Implements;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Book>> GetAll()
    {
        var books = await _context.Book
            .AsNoTracking().ToListAsync();

        return books;
    }

    public Domain.Book? GetBookByIsbnCompiled(string isbn)
    {
        return CompiledQueries.GetByIsbn(_context, isbn);
    }

    public async Task<IEnumerable<Domain.Book>> GetBooksByFilter(BookFilterDto dto)
    {
        var query = _context.Book.Include(x => x.Author).AsQueryable();

        if (!string.IsNullOrWhiteSpace(dto.Title))
        {
            query = query.Where(x => x.Title.Contains(dto.Title));
        }

        if (!string.IsNullOrWhiteSpace(dto.AuthorName))
        {
            query = query.Where(x =>
                x.Author.FirstName.Contains(dto.AuthorName) ||
                x.Author.SecondName.Contains(dto.AuthorName));
        }

        if (dto.MinPrice.HasValue)
        {
            query = query.Where(x => x.Price >= dto.MinPrice.Value);
        }

        if (dto.MaxPrice.HasValue)
        {
            query = query.Where(x => x.Price <= dto.MaxPrice.Value);
        }

        if (dto.MinDate.HasValue)
        {
            query = query.Where(x => x.PublicationDate >= dto.MinDate.Value);
        }

        if (dto.MaxDate.HasValue)
        {
            query = query.Where(x => x.PublicationDate <= dto.MaxDate.Value);
        }

        var books = await query.AsNoTracking().ToListAsync();

        return books;
    }

    public Task Add(Domain.Book book)
    {
        _context.Book.Add(book);
        return _context.SaveChangesAsync();
    }
}