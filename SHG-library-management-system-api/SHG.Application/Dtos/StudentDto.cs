using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Dtos;

public record StudentDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public string? Email { get; set; }

    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}
