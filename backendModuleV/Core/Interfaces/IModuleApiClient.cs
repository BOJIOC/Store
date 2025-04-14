using backendModuleV.Core.DTO.Store;
namespace backendModuleV.Core.Interfaces;

public interface IModuleAApiClient
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByCodeAsync(string code);
    Task<ProductDto> CreateProductAsync(ProductDto product);
    Task<ProductDto?> UpdateProductAsync(int productId, ProductDto product);
}