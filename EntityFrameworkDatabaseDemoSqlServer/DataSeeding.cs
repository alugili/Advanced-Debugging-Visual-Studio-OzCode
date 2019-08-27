using ShopDatabaseDemoSqlServer.Domain;

namespace ShopDatabaseDemoSqlServer
{
  public class DatabaseSeeding
  {
    public void CreateAndSeed()
    {
      using (var dbContext = new ShopDbContext())
      {
        // Generating the database
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        // Adding Products
        const int productCount = 30;
        var products = new Product[productCount];
        for (var i = 0; i < productCount; i++)
        {
          var product = new Product { Description = $"Description {i}", Name = $"Product Name {i}", Price = i };
          dbContext.Products.Add(product);
          products[i] = product;
          // Store inside the loop to simulate a sequential data storing.
          dbContext.SaveChanges();
        }

        var admin = new Admin { Name = "Admin" };

        var customer1 = new Customer { Name = "Customer 1" };
        var customer2 = new Customer { Name = "Customer 2" };
        var customer3 = new Customer { Name = "Customer 3" };

        // Adding Customers
        dbContext.Customers.Add(customer1);
        dbContext.Customers.Add(customer2);
        dbContext.Customers.Add(customer3);
        dbContext.Admins.Add(admin);
        dbContext.SaveChanges();

        // Adding Shop
        var shop = new Shop { Products = products };
        shop.Customers.Add(customer1);
        shop.Customers.Add(customer2);
        shop.Customers.Add(customer3);
        shop.Admins.Add(admin);

        dbContext.Shops.Add(shop);
        dbContext.SaveChanges();

        for (var i = 0; i < 10; i++)
        {
          var order = new Order { Product = products[i], Customer = customer1, Quantity = 1 };
          dbContext.Orders.Add(order);
          // Store inside the loop to simulate a sequential data storing.
          dbContext.SaveChanges();
        }

        for (var i = 10; i < 20; i++)
        {
          var order = new Order { Product = products[i], Customer = customer2, Quantity = 2 };
          dbContext.Orders.Add(order);
          // Store inside the loop to simulate a sequential data storing.
          dbContext.SaveChanges();
        }

        for (var i = 20; i < productCount; i++)
        {
          var order = new Order { Product = products[i], Customer = customer3, Quantity = 3 };
          dbContext.Orders.Add(order);
          // Store inside the loop to simulate a sequential data storing.
          dbContext.SaveChanges();
        }
      }
    }
  }
}