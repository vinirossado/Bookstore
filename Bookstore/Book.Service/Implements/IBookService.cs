namespace Book.Service.Implements;

public interface IBookService
{
    Task<IEnumerable<Domain.Book>> GetAll();
    Domain.Book? GetBookByIsbnCompiled(string isbn);
}