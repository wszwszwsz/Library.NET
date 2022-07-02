using Library.Infrastructure.Entities;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context;

public class MainContext : DbContext
{
    public DbSet<Book> Book { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public MainContext()
    {
        
    }

    public MainContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.Library.db");
    }
    
}