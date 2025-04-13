using backendModuleV.Core.DTO.Store;
using backendModuleV.Core.Interfaces;
using backendModuleV.Infrastructure.Data;

namespace backendModuleV.Infrastructure.Services.InternetStore;

public class InternetStoreService : IInternetStoreService
{
    private readonly IModuleAApiClient _client;
    public InternetStoreService(IModuleAApiClient client) => _client = client;
    public async Task<List<ProductForOnlineDto>> GetOnlineProductsAsync()
    {
        var all = await _client.GetAllProductsAsync();
        return all.Select(x => new ProductForOnlineDto { Group = x.Group, Name = x.Name, Price = x.Price }).ToList();
    }
    public async Task<List<StockInfoDto>> GetStocksAsync(string? storeCode, string? article)
    {
        return new List<StockInfoDto>
        {
            new StockInfoDto
            {
                StoreCode="STORE1",
                StoreName="Магазин №1",
                Items=new List<StockItemDto>
                {
                    new StockItemDto{ProductCode="AAA",ProductName="Товар А",Quantity=10},
                    new StockItemDto{ProductCode="BBB",ProductName="Товар Б",Quantity=20}
                }
            }
        };
    }
    public async Task<int> CreateOnlineOrderAsync(CreateOnlineOrderRequest request)
    {
        return 1;
    }
    public async Task<OrderStatusResponse?> GetOrderStatusAsync(int orderId)
    {
        return new OrderStatusResponse { OrderId = orderId, Status = "Новый", DeliveryDate = DateTime.Now.AddDays(2) };
    }
}