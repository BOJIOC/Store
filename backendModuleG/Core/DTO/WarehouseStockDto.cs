namespace backendModuleG.Core.DTO;

public class WarehouseStockDto
{
    public int Id { get; set; }
    public List<ProductQuantityDto> Products { get; set; } = new();
}