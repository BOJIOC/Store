namespace backendModuleA.Domain.Entities;

public class Movement
{
    public int Id { get; set; }

    public int FromWarehouseId { get; set; }
    public Warehouse FromWarehouse { get; set; } = null!;

    public int ToWarehouseId { get; set; }
    public Warehouse ToWarehouse { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public ICollection<MovementItem> Items { get; set; } = new List<MovementItem>();
}