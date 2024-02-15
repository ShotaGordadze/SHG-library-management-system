using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Dtos;

public record BookDto
{
    public int Id { get; init; }

    public string Title { get; set; }

    public string Image {  get; set; }

    public string Author { get; set; }

    public string? Description { get; set; }
}
