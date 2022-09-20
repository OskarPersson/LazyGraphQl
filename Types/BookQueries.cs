using HotChocolate.Resolvers;
using LazyGraphQl.Data;
using LazyGraphQl.Models;

namespace LazyGraphQl.Types;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookQueries
{
    public IQueryable<Book> GetBooks(LazyGraphQlDbContext context, IResolverContext resolverContext)
        => context.Books;
}