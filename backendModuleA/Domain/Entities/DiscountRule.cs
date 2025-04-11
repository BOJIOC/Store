namespace backendModuleA.Domain.Entities;

public class DiscountRule
{
    public int Id { get; set; }
    public decimal PurchaseThreshold { get; set; }
    public decimal DiscountPercent { get; set; }
}