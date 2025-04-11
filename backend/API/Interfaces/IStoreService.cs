using Courier.Domain.Entities;

namespace Courier.Application.Interfaces;

    public interface IStoreService
    {
        Task<List<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(int id);
        Task AddAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(int id);
    }

