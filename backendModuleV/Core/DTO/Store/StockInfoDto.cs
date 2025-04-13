namespace backendModuleV.Core.DTO.Store;

public class StockInfoDto
{
    public string StoreCode { get; set; } = string.Empty;
    public string StoreName { get; set; } = string.Empty;
    public List<StockItemDto> Items { get; set; } = new();
}

public class StockItemDto
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}