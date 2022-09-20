using Microsoft.EntityFrameworkCore;

namespace LazyGraphQl.Data;

public class LazyGraphQlDbContextFactory
{
    
    private readonly IDbContextFactory<LazyGraphQlDbContext> _pooledFactory;

    public LazyGraphQlDbContextFactory(IDbContextFactory<LazyGraphQlDbContext> pooledFactory)
    {
        _pooledFactory = pooledFactory;
    }

    public LazyGraphQlDbContext CreateDbContext()
    {
        var context = _pooledFactory.CreateDbContext();
        return context;
    }}