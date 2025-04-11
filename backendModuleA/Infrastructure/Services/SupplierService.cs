using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class SupplierService : ISupplierService
{
    private readonly AppDbContext _db;
    public SupplierService(AppDbContext db) => _db = db;

    public async Task<List<Supplier>> GetAllAsync() =>
        await _db.Suppliers.ToListAsync();

    public async Task<Supplier?> GetByIdAsync(int id) =>
        await _db.Suppliers.FindAsync(id);

    public async Task<Supplier> CreateAsync(Supplier supplier)
    {
        _db.Suppliers.Add(supplier);
        await _db.SaveChangesAsync();
        return supplier;
    }

    public async Task<Supplier?> UpdateAsync(Supplier supplier)
    {
        var existing = await _db.Suppliers.FindAsync(supplier.Id);
        if (existing == null) return null;

        existing.Name = supplier.Name;
        existing.Code = supplier.Code;
        existing.ContactInfo = supplier.ContactInfo;
        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var supplier = await _db.Suppliers.FindAsync(id);
        if (supplier == null) return false;
        _db.Suppliers.Remove(supplier);
        await _db.SaveChangesAsync();
        return true;
    }
}