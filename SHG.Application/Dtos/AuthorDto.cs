using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Dtos;

public record AuthorDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public IEnumerable<Book> books { get; set; }
}
