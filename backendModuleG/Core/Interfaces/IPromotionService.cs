using backendModuleG.Core.Entities;

namespace backendModuleG.Core.Interfaces;

public interface IPromotionService
{
    Task<List<Promotion>> GetAllAsync();
    Task<Promotion?> GetByIdAsync(int id);
    Task<Promotion> CreateAsync(Promotion promotion);
    Task<Promotion?> UpdateAsync(Promotion promotion);
    Task<bool> DeleteAsync(int id);
}