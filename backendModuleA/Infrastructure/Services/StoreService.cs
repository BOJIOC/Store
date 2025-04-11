using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class StoreService : IStoreService
{
    private readonly AppDbContext _db;
    public StoreService(AppDbContext db) => _db = db;

    public async Task<List<Store>> GetAllAsync() =>
        await _db.Stores.ToListAsync();

    public async Task<Store?> GetByIdAsync(int id) =>
        await _db.Stores.FindAsync(id);

    public async Task<Store> CreateAsync(Store store)
    {
        _db.Stores.Add(store);
        await _db.SaveChangesAsync();
        return store;
    }

    public async Task<Store?> UpdateAsync(Store store)
    {
        var existing = await _db.Stores.FindAsync(store.Id);
        if (existing == null) return null;

        existing.Name = store.Name;
        existing.Address = store.Address;
        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var store = await _db.Stores.FindAsync(id);
        if (store == null) return false;
        _db.Stores.Remove(store);
        await _db.SaveChangesAsync();
        return true;
    }
}