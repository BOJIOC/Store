using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class SaleService : ISaleService
{
    private readonly AppDbContext _db;
    public SaleService(AppDbContext db) => _db = db;

    public async Task<List<Sale>> GetAllAsync() =>
        await _db.Sales
            .Include(s => s.Items)
            .Include(s => s.Store)
            .Include(s => s.Client)
            .Include(s => s.Employee)
            .ToListAsync();

    public async Task<Sale?> GetByIdAsync(int id) =>
        await _db.Sales
            .Include(s => s.Items)
            .Include(s => s.Store)
            .Include(s => s.Client)
            .Include(s => s.Employee)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Sale> CreateAsync(Sale sale)
    {
        sale.TotalAmount = sale.Items.Sum(i => i.Price * i.Quantity);
        _db.Sales.Add(sale);
        await _db.SaveChangesAsync();
        return sale;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sale = await _db.Sales.FindAsync(id);
        if (sale == null) return false;
        _db.Sales.Remove(sale);
        await _db.SaveChangesAsync();
        return true;
    }
}