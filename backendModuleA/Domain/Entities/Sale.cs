namespace backendModuleA.Domain.Entities;

public class Sale
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public decimal DiscountPercent { get; set; }

    public ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();
}