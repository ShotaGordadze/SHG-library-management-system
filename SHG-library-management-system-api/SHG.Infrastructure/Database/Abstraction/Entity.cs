namespace SHG.Infrastructure.Database.Abstraction;

public abstract class Entity
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastChangeDate { get; set; }
}
