using BookManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-J8MP9FT\\SQLEXPRESS;Initial Catalog=BookManager;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
    }
}
