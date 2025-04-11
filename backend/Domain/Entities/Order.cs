namespace Courier.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string State { get; set; } // Новый, Собран, Доставлен
    public string ClientName { get; set; }
    public string Address { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string Comment { get; set; }

    public int? CollectorId { get; set; }
    public Employee? Collector { get; set; }

    public int? CourierId { get; set; }
    public Employee? Courier { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; }

    public List<OrderItem> Items { get; set; } = new();
}