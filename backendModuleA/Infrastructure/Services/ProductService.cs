using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _db;

    public ProductService(AppDbContext db) => _db = db;

    public async Task<List<Product>> GetAllAsync() =>
        await _db.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _db.Products.FindAsync(id);

    public async Task<Product> CreateAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateAsync(Product product)
    {
        var existing = await _db.Products.FindAsync(product.Id);
        if (existing == null) return null;

        existing.Name = product.Name;
        existing.Brand = product.Brand;
        existing.Group = product.Group;
        existing.PriceHistory = product.PriceHistory;
        existing.ImageUrl = product.ImageUrl;

        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Products.FindAsync(id);
        if (existing == null) return false;

        _db.Products.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}