namespace SHG.Api.Models;

public record AuthorModel(string Name, string Lastname);

public record AuthorUpdateNameModel(string Name);

public record AuthorUpdateLastnameModel(string Lastname);

public record StudentModel(string Name, string Email);

public record StudentUpdateNameModel(string Name);

public record StudentUpdateLastnameModel(string Lastname);

public record BookModel(string Name, string Email);

public record CategoryModel(string Name, string? Description);