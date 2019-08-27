namespace ShopDatabaseDemoSqlServer.Domain
{
  public class Order
  {
    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public Customer Customer { get; set; } = new Customer();

    public Product Product { get; set; } = new Product();
  }
}