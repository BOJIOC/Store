namespace Courier.Domain.Entities;

public class DeliveryReport
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Type { get; set; } = ""; // "Сборка" или "Доставка"
    public DateTime Date { get; set; }
    public int OrderCount { get; set; }
}