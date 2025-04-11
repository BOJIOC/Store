using Courier.SharedModels;

namespace Courier.Application.Interfaces;

public interface IRetailApiClient
{
    Task<List<ProductDto>> GetProductsAsync();
    Task<List<EmployeeDto>> GetEmployeesAsync();
    Task<List<StoreDto>> GetStoresAsync();
}