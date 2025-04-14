using System.Net.Http.Json;
using backendModuleG.Core.DTO;
using backendModuleG.Core.Interfaces;
using backendModuleG.Core.Models;

namespace backendModuleG.Infrastructure.Services;

public class ProfitAnalysisService : IProfitAnalysisService
{
    private readonly HttpClient _http;

    public ProfitAnalysisService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProfitResult>> GetProfitableProductsAsync(DateTime from, DateTime to)
    {
        var url = $"api/Sale?from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}";
        var sales = await _http.GetFromJsonAsync<List<SaleDto>>(url);

        var result = sales!
            .GroupBy(s => new { s.ProductId, s.ProductName, s.SalePrice, s.PurchasePrice })
            .Select(g => new ProfitResult
            {
                ProductId = g.Key.ProductId,
                ProductName = g.Key.ProductName,
                TotalProfit = g.Sum(s => (s.SalePrice - s.PurchasePrice) * s.Quantity)
            })
            .OrderByDescending(p => p.TotalProfit)
            .ToList();

        return result;
    }
}