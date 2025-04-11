using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface IStoreService
{
    Task<List<Store>> GetAllAsync();
    Task<Store?> GetByIdAsync(int id);
    Task<Store> CreateAsync(Store store);
    Task<Store?> UpdateAsync(Store store);
    Task<bool> DeleteAsync(int id);
}