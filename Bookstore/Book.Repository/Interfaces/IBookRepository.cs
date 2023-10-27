namespace Book.Repository.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Domain.Book>> GetAll();
    Domain.Book? GetBookByIsbnCompiled(string isbn);
}