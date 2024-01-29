using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Author : Entity
{
    public string Name { get; set; }

    public string Lastname { get; set; }

    public DateTime BirthDate { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
