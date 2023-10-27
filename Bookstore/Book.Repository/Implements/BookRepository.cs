using Book.Infra.CrossCutting.Context;
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
        var books = await _context.Book.AsNoTracking().ToListAsync();

        return books;
    }
}