namespace backendModuleA.Domain.Entities;

public class Store
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}