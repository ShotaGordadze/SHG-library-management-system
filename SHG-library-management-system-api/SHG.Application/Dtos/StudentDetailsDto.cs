namespace SHG.Infrastructure.Database.Entities;

public class StudentDetailsDto 
{
    public Guid Id { get; set; } 

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastChangeDate { get; set; }

    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}
