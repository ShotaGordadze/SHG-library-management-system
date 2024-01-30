namespace SHG.Api.Models;

public record AuthorModel(string Name, string Lastname);

public record StudentModel(string Name, string Email);

public record BookModel(string Name, string Email);

public record CategoryModel(string Name, string? Description);