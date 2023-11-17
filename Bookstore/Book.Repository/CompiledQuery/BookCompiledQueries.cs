using Book.Infra.CrossCutting.Context;
using Microsoft.EntityFrameworkCore;

namespace Book.Repository.CompiledQuery;

public static class CompiledQueries
{
    public static readonly Func<ApplicationDbContext, string, Domain.Book?> GetByIsbn =
        EF.CompileQuery(
            (ApplicationDbContext AppDbContext, string isbn) =>
                AppDbContext.Book.FirstOrDefault(x => x.Isbn == isbn));
}