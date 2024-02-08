using Microsoft.AspNetCore.Identity;

namespace SHG.Infrastructure.Database.Entities;

public class User : IdentityUser<Guid>
{
    public string Email {  get; set; }

    public string Password { get; set; }
}
