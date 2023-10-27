namespace Book.Service.Implements;

public interface IBookService
{
    Task<IEnumerable<Domain.Book>> GetAll();
}