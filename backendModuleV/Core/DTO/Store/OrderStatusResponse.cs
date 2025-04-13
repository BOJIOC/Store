namespace backendModuleV.Core.DTO.Store;

public class OrderStatusResponse
{
    public int OrderId { get; set; }
    public string Status { get; set; } = "Новый";
    public DateTime? DeliveryDate { get; set; }
}