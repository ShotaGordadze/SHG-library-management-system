using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Student : Entity 
{
    public Student(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    public DateTime Updated { get; set; }

    public IEnumerable<Book> Books { get; set; }
}
