using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SHG.Infrastructure.Database;

public class LibraryDbContext : IdentityDbContext<User,Role,Guid>
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContext)
        : base(dbContext)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=LibraryManagementSystem;Pooling=true;")
                      .UseSnakeCaseNamingConvention();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("Users", "identity");
        modelBuilder.Entity<Role>().ToTable("Roles", "identity");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "identity");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "identity");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "identity");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "identity");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "identity");

        var authorEntity = modelBuilder.Entity<Author>();

        authorEntity.ToTable("Authors")
                    .HasKey(x => x.Id);

        authorEntity.HasMany(e => e.Books)
                    .WithOne(e => e.Author);

        var bookEntity = modelBuilder.Entity<Book>();

        bookEntity.ToTable("Books")
                  .HasKey(e => e.Id);

        bookEntity.HasMany(e => e.Categories)
                  .WithMany(e => e.Books)
                  .UsingEntity(j => j.ToTable("BookCategory"));

        var studentEntity = modelBuilder.Entity<Student>();

        studentEntity.ToTable("Students")
                     .HasKey(e => e.Id);

        studentEntity.HasMany(e => e.Books)
                     .WithMany(e => e.Students)
                     .UsingEntity(j => j.ToTable("StudentBook"));

        var categoryEntity = modelBuilder.Entity<Category>();

        categoryEntity.ToTable("Categories")
                      .HasKey(e => e.Id);

        categoryEntity.HasMany(e => e.Books)
                      .WithMany(e => e.Categories)
                      .UsingEntity(e => e.ToTable("BookCategory"));
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Student> Students { get; set; }
}