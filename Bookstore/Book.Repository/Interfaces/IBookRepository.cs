using Book.Infra.CrossCutting.Dtos;

namespace Book.Repository.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Domain.Book>> GetAll();
    Domain.Book? GetBookByIsbnCompiled(string isbn);
    Task<IEnumerable<Domain.Book>> GetBooksByFilter(BookFilterDto dto);
    Task Add(Domain.Book book);
}