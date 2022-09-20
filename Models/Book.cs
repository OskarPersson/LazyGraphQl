namespace LazyGraphQl.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public virtual Author? Author { get; set; }
}
