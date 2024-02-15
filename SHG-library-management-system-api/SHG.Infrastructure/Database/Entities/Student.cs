using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Student : Entity 
{
    public string Name { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }

    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}
