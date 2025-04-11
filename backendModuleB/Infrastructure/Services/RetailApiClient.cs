using System.Net.Http.Json;
using Courier.Application.Interfaces;
using Courier.SharedModels;

namespace Courier.Infrastructure.Services;

public class RetailApiClient : IRetailApiClient
{
    private readonly HttpClient _http;

    public RetailApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProductDto>> GetProductsAsync() =>
        await _http.GetFromJsonAsync<List<ProductDto>>("api/product") ?? new();

    public async Task<List<EmployeeDto>> GetEmployeesAsync() =>
        await _http.GetFromJsonAsync<List<EmployeeDto>>("api/employee") ?? new();

    public async Task<List<StoreDto>> GetStoresAsync() =>
        await _http.GetFromJsonAsync<List<StoreDto>>("api/store") ?? new();
}