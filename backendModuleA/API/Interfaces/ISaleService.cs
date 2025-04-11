using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface ISaleService
{
    Task<List<Sale>> GetAllAsync();
    Task<Sale?> GetByIdAsync(int id);
    Task<Sale> CreateAsync(Sale sale);
    Task<bool> DeleteAsync(int id);
}