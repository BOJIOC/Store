using backendModuleA.Domain.Entities;

namespace backendModuleA.API.Interfaces;

public interface IClientService
{
    Task<List<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<Client> CreateAsync(Client client);
    Task<Client?> UpdateAsync(Client client);
    Task<bool> DeleteAsync(int id);
}