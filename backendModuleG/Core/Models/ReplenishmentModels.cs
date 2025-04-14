namespace backendModuleG.Core.Models;

public class ReplenishmentRequest
{
    public int MainWarehouseId { get; set; }
    public List<StoreInfo> Stores { get; set; } = new();
}

public class StoreInfo
{
    public int StoreId { get; set; }
    public int Priority { get; set; }
}

public class ReplenishmentResult
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public List<ReplenishmentItem> Items { get; set; } = new();
}

public class ReplenishmentItem
{
    public int StoreId { get; set; }
    public int Quantity { get; set; }
}