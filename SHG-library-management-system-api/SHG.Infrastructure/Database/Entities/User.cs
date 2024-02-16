using Microsoft.AspNetCore.Identity;

namespace SHG.Infrastructure.Database.Entities;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }

    public string Lastname { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastChangeDate { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
}
