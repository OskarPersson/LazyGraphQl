using LazyGraphQl.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyGraphQl.Data;

public class LazyGraphQlDbContext: DbContext
{
    
    public LazyGraphQlDbContext(DbContextOptions<LazyGraphQlDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
}