namespace backendModuleG.Core.DTO;

public class SaleDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Quantity { get; set; }
}