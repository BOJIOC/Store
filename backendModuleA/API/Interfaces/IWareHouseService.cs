using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface IWarehouseService
{
    Task<List<Warehouse>> GetAllAsync();
    Task<Warehouse?> GetByIdAsync(int id);
    Task<Warehouse> CreateAsync(Warehouse warehouse);
    Task<Warehouse?> UpdateAsync(Warehouse warehouse);
    Task<bool> DeleteAsync(int id);
}