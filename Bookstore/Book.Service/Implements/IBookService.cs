using Book.Infra.CrossCutting.Dtos;

namespace Book.Service.Implements;

public interface IBookService
{
    Task<IEnumerable<Domain.Book>> GetAll();
    Domain.Book? GetBookByIsbnCompiled(string isbn);
    Task<IEnumerable<Domain.Book>> GetBooksByFilter(BookFilterDto dto);
}