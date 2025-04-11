namespace backendModuleA.Domain.Entities;

public class InventoryItem
{
    public int Id { get; set; }

    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int ExpectedQuantity { get; set; }
    public int ActualQuantity { get; set; }
}