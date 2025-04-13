using backendModuleV.Core.DTO.Store;

namespace backendModuleV.Core.Interfaces;

public interface IInternetStoreService
{
    Task<List<ProductForOnlineDto>> GetOnlineProductsAsync();
    Task<List<StockInfoDto>> GetStocksAsync(string? storeCode, string? article);
    Task<int> CreateOnlineOrderAsync(CreateOnlineOrderRequest request);
    Task<OrderStatusResponse?> GetOrderStatusAsync(int orderId);
}