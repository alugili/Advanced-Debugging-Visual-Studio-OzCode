using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShopDatabaseDemoSqlServer.Domain
{
  public class Customer  
  {
    public int CustomerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new Collection<Order>();
  }
}