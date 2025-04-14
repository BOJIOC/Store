using backendModuleG.Core.Models;

namespace backendModuleG.Core.Interfaces;

public interface IReplenishmentService
{
    Task<List<ReplenishmentResult>> ProposeReplenishmentAsync(ReplenishmentRequest request);
    Task<bool> ExecuteReplenishmentAsync(List<ReplenishmentResult> results);
}