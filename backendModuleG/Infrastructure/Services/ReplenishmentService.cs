using System.Net.Http.Json;
using backendModuleG.Core.DTO;
using backendModuleG.Core.Interfaces;
using backendModuleG.Core.Models;

namespace backendModuleG.Infrastructure.Services;

public class ReplenishmentService : IReplenishmentService
{
    private readonly HttpClient _http;

    public ReplenishmentService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<List<ReplenishmentResult>> ProposeReplenishmentAsync(ReplenishmentRequest request)
    {
        var products = await _http.GetFromJsonAsync<List<ProductDto>>("api/Product");
        var warehouseStocks = await _http.GetFromJsonAsync<List<WarehouseStockDto>>("api/Warehouse");
        var storeStocks = await _http.GetFromJsonAsync<List<StoreStockDto>>("api/Store");

        var results = new List<ReplenishmentResult>();

        foreach (var product in products!)
        {
            if (product.MinStock == null || product.MaxStock == null)
                continue;

            var mainStock = warehouseStocks!
                .FirstOrDefault(w => w.Id == request.MainWarehouseId)?
                .Products?.FirstOrDefault(p => p.ProductId == product.Id)?.Quantity ?? 0;

            var result = new ReplenishmentResult
            {
                ProductId = product.Id,
                ProductName = product.Name
            };

            foreach (var store in request.Stores.OrderBy(s => s.Priority))
            {
                var storeStock = storeStocks!
                    .FirstOrDefault(s => s.Id == store.StoreId)?
                    .Products?.FirstOrDefault(p => p.ProductId == product.Id)?.Quantity ?? 0;

                if (storeStock < product.MinStock)
                {
                    var needed = (int)(product.MaxStock - storeStock);
                    var toSend = Math.Min(needed, mainStock);

                    if (toSend > 0)
                    {
                        result.Items.Add(new ReplenishmentItem
                        {
                            StoreId = store.StoreId,
                            Quantity = toSend
                        });

                        mainStock -= toSend;
                    }
                }

                if (mainStock <= 0) break;
            }

            if (result.Items.Any())
                results.Add(result);
        }

        return results;
    }

    public async Task<bool> ExecuteReplenishmentAsync(List<ReplenishmentResult> results)
    {
        foreach (var result in results)
        {
            foreach (var item in result.Items)
            {
                var movement = new
                {
                    ProductId = result.ProductId,
                    FromWarehouseId = 1,
                    ToStoreId = item.StoreId,
                    Quantity = item.Quantity
                };

                var response = await _http.PostAsJsonAsync("api/Movement", movement);
                if (!response.IsSuccessStatusCode)
                    return false;
            }
        }

        return true;
    }
}