namespace backendModuleA.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public ICollection<PriceHistory> PriceHistory { get; set; } = new List<PriceHistory>();
    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    public ICollection<MovementItem> MovementItems { get; set; } = new List<MovementItem>();
}