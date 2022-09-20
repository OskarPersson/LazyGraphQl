using LazyGraphQl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var dbdir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var dbpath = System.IO.Path.Join(dbdir, "lazy.db");
builder.Services.AddPooledDbContextFactory<LazyGraphQlDbContext>(options =>
    options.UseSqlite($"Data Source={dbpath}").UseLazyLoadingProxies()
);

builder.Services
    .AddGraphQLServer()
    .InitializeOnStartup()
    .AddQueryType()
    .AddLazyGraphQlTypes()
    .RegisterDbContext<LazyGraphQlDbContext>(DbContextKind.Pooled);

builder.Services.AddScoped<LazyGraphQlDbContextFactory>();
builder.Services.AddScoped(
    sp => sp.GetRequiredService<LazyGraphQlDbContextFactory>().CreateDbContext());

var app = builder.Build();

app.MapGet("/", (LazyGraphQlDbContext context) =>
{
    return string.Join(",", context.Books.Select(b => $"{b.Title} ({b.Author.Name})").ToList());
});
app.MapGraphQL();
app.Run();