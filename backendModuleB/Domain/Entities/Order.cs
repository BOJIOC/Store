namespace Courier.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public int CourierId { get; set; }
    public int CollectorId { get; set; }

    public string ClientName { get; set; } = "";
    public string Address { get; set; } = "";
    public string Comment { get; set; } = "";

    public string Status { get; set; } = "Новый"; // Новый, Собран, Доставлен
    public DateTime DeliveryDate { get; set; }

    public List<OrderItem> Items { get; set; } = new();
}