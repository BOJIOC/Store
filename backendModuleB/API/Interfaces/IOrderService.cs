using Courier.Domain.Entities;

namespace Courier.Application.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task UpdateAsync(Order order);
}