using Microsoft.AspNetCore.Identity;

namespace SHG.Infrastructure.Database.Entities;

public class User : IdentityUser<Guid>
{
    //public string Name { get; set; }

    //public string Lastname { get; set; }

    //public IEnumerable<Book> Books { get; set; } = new List<Book>();
}
