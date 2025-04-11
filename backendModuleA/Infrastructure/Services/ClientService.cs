using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class ClientService : IClientService
{
    private readonly AppDbContext _db;
    public ClientService(AppDbContext db) => _db = db;

    public async Task<List<Client>> GetAllAsync() =>
        await _db.Clients.ToListAsync();

    public async Task<Client?> GetByIdAsync(int id) =>
        await _db.Clients.FindAsync(id);

    public async Task<Client> CreateAsync(Client client)
    {
        _db.Clients.Add(client);
        await _db.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> UpdateAsync(Client client)
    {
        var existing = await _db.Clients.FindAsync(client.Id);
        if (existing == null) return null;

        existing.Name = client.Name;
        existing.Code = client.Code;
        existing.ContactInfo = client.ContactInfo;
        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var client = await _db.Clients.FindAsync(id);
        if (client == null) return false;
        _db.Clients.Remove(client);
        await _db.SaveChangesAsync();
        return true;
    }
}