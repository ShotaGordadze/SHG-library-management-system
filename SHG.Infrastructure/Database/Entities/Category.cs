using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Category : Entity
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<Book> Books { get; set; }
}
