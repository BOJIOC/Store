using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface IInventoryService
{
    Task<List<Inventory>> GetAllAsync();
    Task<Inventory?> GetByIdAsync(int id);
    Task<Inventory> CreateAsync(Inventory inventory);
    Task<bool> FinalizeInventoryAsync(int id);
    Task<bool> DeleteAsync(int id);
}