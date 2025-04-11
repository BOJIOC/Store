namespace backendModuleA.Domain.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public ICollection<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();
}