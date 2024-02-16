using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure.Database.Entities;

public class Book : Entity
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public string Image { get; set; }

    public Author Author { get; set; }

    public int AuthorId { get; set; }

    public DateTime? IssueStartDate { get; set; } = null;

    public DateTime? IssueEndDate { get; set; } = null;

    public IEnumerable<Category> Categories { get; set; } = new List<Category>();

    public IEnumerable<User> Users { get; set; } = new List<User>();
}
