using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface IMovementService
{
    Task<List<Movement>> GetAllAsync();
    Task<Movement?> GetByIdAsync(int id);
    Task<Movement> CreateAsync(Movement movement);
    Task<bool> DeleteAsync(int id);
}