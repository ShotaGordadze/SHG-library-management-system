using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Student : Entity 
{
    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    public DateTime Updated { get; set; }

    public IEnumerable<Book> Books { get; set; }
}
