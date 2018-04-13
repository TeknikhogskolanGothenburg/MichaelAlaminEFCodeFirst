using MichaelAlaminEFCodeFirstProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace MichaelAlaminEFCodeFirstProject.Data
{
    public class AppDbContext :  DbContext
    {
       

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public static readonly LoggerFactory BookLoggerFactory
      = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true)
    });



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>() //  one-to-many förhållande gemon  Fluent API 
            .HasOne<Category>(s => s.Category)
            .WithMany(g => g.Books)
            .HasForeignKey(s => s.CategoryId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .EnableSensitiveDataLogging()
                 .UseLoggerFactory(BookLoggerFactory)
                 .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = MichaelAlaminEfDb; Trusted_Connection = True;");
           

        }
    }
}
