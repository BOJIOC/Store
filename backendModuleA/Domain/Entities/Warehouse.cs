namespace backendModuleA.Domain.Entities;

public class Warehouse
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public ICollection<Movement> MovementsFrom { get; set; } = new List<Movement>();
    public ICollection<Movement> MovementsTo { get; set; } = new List<Movement>();
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}