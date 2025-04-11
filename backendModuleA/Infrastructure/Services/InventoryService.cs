using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _db;
    public InventoryService(AppDbContext db) => _db = db;

    public async Task<List<Inventory>> GetAllAsync() =>
        await _db.Inventories
            .Include(i => i.Items)
            .ThenInclude(ii => ii.Product)
            .ToListAsync();

    public async Task<Inventory?> GetByIdAsync(int id) =>
        await _db.Inventories
            .Include(i => i.Items)
            .ThenInclude(ii => ii.Product)
            .FirstOrDefaultAsync(i => i.Id == id);

    public async Task<Inventory> CreateAsync(Inventory inventory)
    {
        _db.Inventories.Add(inventory);
        await _db.SaveChangesAsync();
        return inventory;
    }

    public async Task<bool> FinalizeInventoryAsync(int id)
    {
        var inventory = await _db.Inventories.Include(i => i.Items).FirstOrDefaultAsync(i => i.Id == id);
        if (inventory == null) return false;

        inventory.Status = "Завершена";
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var inventory = await _db.Inventories.FindAsync(id);
        if (inventory == null) return false;
        _db.Inventories.Remove(inventory);
        await _db.SaveChangesAsync();
        return true;
    }
}