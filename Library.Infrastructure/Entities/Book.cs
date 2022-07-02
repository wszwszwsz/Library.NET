namespace Library.Infrastructure.Entities;

public class Book : BaseEntity
{
    public string? Name { get; set; }
    public string? Genre { get; set; }
    public Book? Books { get; set; } 
}