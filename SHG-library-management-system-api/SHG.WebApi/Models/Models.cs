namespace SHG.WebApi.Models;

public record AuthorModel(string Name, string Lastname);

public record AuthorUpdateNameModel(string Name);

public record AuthorUpdateLastnameModel(string Lastname);

public record StudentModel(string Name, string Email);

public record StudentUpdateNameModel(string Name);

public record StudentUpdateLastnameModel(string Lastname);

public record CategoryModel(string Name, string? Description);

public record SignUpModel(string Email, string Password);

public record SignInModel(string Email, string Password);

public record RoleModel(string Name);

public record BookModel(string Title, int AuthorId);