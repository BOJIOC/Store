namespace backendModuleV.Core.DTO.Store;

public class CreateOnlineOrderRequest
{
    public string ClientName { get; set; } = string.Empty;
    public string ClientAddress { get; set; } = string.Empty;
    public string ClientPhone { get; set; } = string.Empty;
    public List<CreateOnlineOrderItem> Items { get; set; } = new();
}

public class CreateOnlineOrderItem
{
    public string ProductCode { get; set; } = string.Empty;
    public int Quantity { get; set; }
}