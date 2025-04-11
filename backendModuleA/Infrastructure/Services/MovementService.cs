using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure.Services;

public class MovementService : IMovementService
{
    private readonly AppDbContext _db;
    public MovementService(AppDbContext db) => _db = db;

    public async Task<List<Movement>> GetAllAsync() =>
        await _db.Movements
            .Include(m => m.Items)
            .Include(m => m.FromWarehouse)
            .Include(m => m.ToWarehouse)
            .ToListAsync();

    public async Task<Movement?> GetByIdAsync(int id) =>
        await _db.Movements
            .Include(m => m.Items)
            .Include(m => m.FromWarehouse)
            .Include(m => m.ToWarehouse)
            .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Movement> CreateAsync(Movement movement)
    {
        _db.Movements.Add(movement);
        await _db.SaveChangesAsync();
        return movement;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movement = await _db.Movements.FindAsync(id);
        if (movement == null) return false;
        _db.Movements.Remove(movement);
        await _db.SaveChangesAsync();
        return true;
    }
}