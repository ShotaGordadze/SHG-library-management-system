using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Dtos;

public record CategoryDto
{
    public int Id { get; init; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<Book> books { get; set; } = new List<Book>();
}
