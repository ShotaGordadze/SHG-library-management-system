using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Book : Entity
{
    public string Title { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public Author Author { get; set; }

    public string AuthorId { get; set; }

    public IEnumerable<Category> Categories { get; set; }

    public IEnumerable<Student> Students { get; set; }
}
