namespace Courier.Domain.Entities;

public class CourierSettings
{
    public int Id { get; set; } = 1; // Singleton запись
    public int CurrentEmployeeId { get; set; }
}