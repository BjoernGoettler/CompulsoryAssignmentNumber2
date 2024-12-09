using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.DbContexts;

public class BookstoreContext: DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey("AuthorId");
    }
}
