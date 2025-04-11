namespace backendModuleA.Domain.Entities;

public class Inventory
{
    public int Id { get; set; }

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Черновик";

    public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}