using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface ISupplierService
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(int id);
    Task<Supplier> CreateAsync(Supplier supplier);
    Task<Supplier?> UpdateAsync(Supplier supplier);
    Task<bool> DeleteAsync(int id);
}