using System.Net.Http.Json;

namespace backendModuleV.Infrastructure.Data;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
}

public interface IModuleAApiClient
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByCodeAsync(string code);
    Task<ProductDto> CreateProductAsync(ProductDto product);
    Task<ProductDto?> UpdateProductAsync(int productId, ProductDto product);
}

public class ModuleAApiClient : IModuleAApiClient
{
    private readonly HttpClient _http;
    public ModuleAApiClient(HttpClient http) => _http = http;
    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var r = await _http.GetAsync("api/Product");
        r.EnsureSuccessStatusCode();
        var list = await r.Content.ReadFromJsonAsync<List<ProductDto>>();
        return list ?? new List<ProductDto>();
    }
    public async Task<ProductDto?> GetProductByCodeAsync(string code)
    {
        var all = await GetAllProductsAsync();
        return all.FirstOrDefault(x => x.Code == code);
    }
    public async Task<ProductDto> CreateProductAsync(ProductDto product)
    {
        var r = await _http.PostAsJsonAsync("api/Product", product);
        r.EnsureSuccessStatusCode();
        return (await r.Content.ReadFromJsonAsync<ProductDto>())!;
    }
    public async Task<ProductDto?> UpdateProductAsync(int productId, ProductDto product)
    {
        var r = await _http.PutAsJsonAsync($"api/Product/{productId}", product);
        if (!r.IsSuccessStatusCode) return null;
        return await r.Content.ReadFromJsonAsync<ProductDto>();
    }
}