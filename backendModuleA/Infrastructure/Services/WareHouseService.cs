using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class WarehouseService : IWarehouseService
{
    private readonly AppDbContext _db;
    public WarehouseService(AppDbContext db) => _db = db;

    public async Task<List<Warehouse>> GetAllAsync() =>
        await _db.Warehouses.ToListAsync();

    public async Task<Warehouse?> GetByIdAsync(int id) =>
        await _db.Warehouses.FindAsync(id);

    public async Task<Warehouse> CreateAsync(Warehouse warehouse)
    {
        _db.Warehouses.Add(warehouse);
        await _db.SaveChangesAsync();
        return warehouse;
    }

    public async Task<Warehouse?> UpdateAsync(Warehouse warehouse)
    {
        var existing = await _db.Warehouses.FindAsync(warehouse.Id);
        if (existing == null) return null;

        existing.Name = warehouse.Name;
        existing.Address = warehouse.Address;
        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var warehouse = await _db.Warehouses.FindAsync(id);
        if (warehouse == null) return false;

        _db.Warehouses.Remove(warehouse);
        await _db.SaveChangesAsync();
        return true;
    }
}