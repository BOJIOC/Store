using backendModuleG.Core.Entities;
using backendModuleG.Core.Interfaces;
using backendModuleG.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backendModuleG.Infrastructure.Services;

public class PromotionService : IPromotionService
{
    private readonly ModuleGDbContext _context;

    public PromotionService(ModuleGDbContext context)
    {
        _context = context;
    }

    public async Task<List<Promotion>> GetAllAsync() => await _context.Promotions.ToListAsync();

    public async Task<Promotion?> GetByIdAsync(int id) =>
        await _context.Promotions.FindAsync(id);

    public async Task<Promotion> CreateAsync(Promotion promotion)
    {
        _context.Promotions.Add(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }

    public async Task<Promotion?> UpdateAsync(Promotion promotion)
    {
        if (!_context.Promotions.Any(p => p.Id == promotion.Id)) return null;

        _context.Promotions.Update(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var promo = await _context.Promotions.FindAsync(id);
        if (promo == null) return false;

        _context.Promotions.Remove(promo);
        await _context.SaveChangesAsync();
        return true;
    }
}