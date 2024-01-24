using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Category : Entity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public Book Book { get; set; }

    public IEnumerable<Book> Books { get; set; }
}
