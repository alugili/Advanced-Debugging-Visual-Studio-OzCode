using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopDatabaseDemoSqlServer.Domain;

namespace ShopDatabaseDemoSqlServer
{
  class Program
  {
    static void Main(string[] args)
    {
      CreateAndSeedDb();

      FiveOrders();
      TraceOrders();
      Customers();
    }

    private static void CreateAndSeedDb()
    {
      var dataSeeding = new DatabaseSeeding();
      dataSeeding.CreateAndSeed();
    }

    private static void FiveOrders()
    {
      using (var dbContext = new ShopDbContext())
      {
        var shopQuery = dbContext.Shops.Include(x => x.Products)
          .Include(x => x.Admins)
          .Include(x => x.Customers)
          .ThenInclude(x => x.Orders);

        var firstOrders = shopQuery
          .SelectMany(c => c.Customers)
          .SelectMany(o => o.Orders)
          .Where(s => s.Quantity > 1)
          .Skip(2)
          .Take(15)
          .OrderByDescending(x => x.OrderId);

        foreach (var order in firstOrders)
        {
          Console.WriteLine(order);
        }
      }
    }

    private static void Customers()
    {
      using (var dbContext = new ShopDbContext())
      {
        var shopQuery = dbContext.Shops.Include(x => x.Products)
                                       .Include(x => x.Admins)
                                       .Include(x => x.Customers)
                                       .ThenInclude(x => x.Orders);

        var shop = shopQuery.First();

        var customers = shop.Customers
          .Select(c => c)
          .Where(s => s.CustomerId == 1)
          .Take(1)
          .OrderByDescending(x => x.Name);

        foreach (var customer in customers)
        {
          Console.WriteLine(customer);
        }
      }
    }

    private static void TraceOrders()
    {
      for (var i = 1; i < 10; i++)
      {
        Console.WriteLine(GetOrder(i));
      }
    }

    private static Order GetOrder(int orderId)
    {
      using (var dbContext = new ShopDbContext())
      {
        var ordersQuery = dbContext.Orders.Include(x => x.Customer).Include(x => x.Product);
        return ordersQuery.Single(x => x.OrderId == orderId);
      }
    }
  }
}