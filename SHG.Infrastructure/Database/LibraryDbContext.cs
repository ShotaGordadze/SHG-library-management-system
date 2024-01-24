using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database.Entities;

namespace SHG.Infrastructure.Database;

public class LibraryDbContext : DbContext
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
        optionsBuilder.UseNpgsql("User ID=sa;Password=123456;Host=localhost;Port=5432;Database=LibraryManagementSystem;Pooling=true;")
                      .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var authorEntity = modelBuilder.Entity<Author>();

        authorEntity.ToTable("Authors")
                    .HasKey(a => a.Id);

        authorEntity.HasMany(a => a.Books)
                    .WithOne(b => b.Author)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

        var bookEntity = modelBuilder.Entity<Book>();

        bookEntity.ToTable("Books")
                   .HasKey(b => b.Id);

        bookEntity.HasMany(c => c.Categories)
                   .WithMany(d => d.Books)
                   .UsingEntity(j => j.ToTable("BookCategory"));

        var studentEntity = modelBuilder.Entity<Student>();

        studentEntity.ToTable("Students")
                     .HasKey(s => s.Id);

        studentEntity.HasMany(s => s.Books)
                     .WithMany(b => b.Students)
                     .UsingEntity(j => j.ToTable("StudentBook"));

        var categoryEntity = modelBuilder.Entity<Category>();

        categoryEntity.ToTable("Categories")
                      .HasKey(c => c.Id);

        categoryEntity.HasOne(c => c.Book)
                      .WithMany();
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Student> Students { get; set; }
}
