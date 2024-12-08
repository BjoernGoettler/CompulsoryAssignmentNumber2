using Microsoft.EntityFrameworkCore;

namespace Database.Models;

public class BookstoreContext: DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
    {
    }
}
