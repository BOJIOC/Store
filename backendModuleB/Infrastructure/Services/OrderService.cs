using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Courier.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Courier.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync() =>
        await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) =>
        await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}