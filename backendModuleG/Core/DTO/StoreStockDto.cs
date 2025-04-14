namespace backendModuleG.Core.DTO;

public class StoreStockDto
{
    public int Id { get; set; }
    public List<ProductQuantityDto> Products { get; set; } = new();
}