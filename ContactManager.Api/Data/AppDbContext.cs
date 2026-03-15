using Microsoft.EntityFrameworkCore;
using ContactManager;

namespace ContactManager.Api.Data;

// DbContext is the bridge between your C# code and the SQLite database
// It tracks your Contact objects and translates them into database operations
public class AppDbContext : DbContext
{
    // This constructor lets ASP.NET inject the database configuration automatically
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSet represents a table in the database
    // This creates a "Contacts" table with columns for Name, Phone, and Email
    public DbSet<Contact> Contacts { get; set; }
}