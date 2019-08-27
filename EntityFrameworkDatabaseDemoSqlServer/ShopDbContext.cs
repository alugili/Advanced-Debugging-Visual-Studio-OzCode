using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShopDatabaseDemoSqlServer.Domain;

namespace ShopDatabaseDemoSqlServer
{
  public class ShopDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Shop> Shops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
                    .UseSqlServer(@"Server=.\;Database=ShopDatabase;Trusted_Connection=True;")
                    .UseLoggerFactory(GenerateLoggerFactory())
                    .EnableSensitiveDataLogging();
    }

    private ILoggerFactory GenerateLoggerFactory()
    {
      var serviceCollection = new ServiceCollection();
      serviceCollection.AddLogging(builder => builder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Trace));

      return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
    }
  }
}