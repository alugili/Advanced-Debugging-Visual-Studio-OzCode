using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShopDatabaseDemoSqlServer.Domain
{
  public class Shop
  {
    public int ShopId { get; set; }

    public ICollection<Admin> Admins { get; set; } = new Collection<Admin>();

    public ICollection<Customer> Customers { get; set; } = new Collection<Customer>();

    public ICollection<Product> Products { get; set; } = new Collection<Product>();
  }
}