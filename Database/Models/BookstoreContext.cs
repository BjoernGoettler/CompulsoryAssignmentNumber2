using Microsoft.EntityFrameworkCore;

namespace Database.Models;

public class BookstoreContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
