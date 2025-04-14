using backendModuleG.Core.Models;

namespace backendModuleG.Core.Interfaces;

public interface IProfitAnalysisService
{
    Task<List<ProfitResult>> GetProfitableProductsAsync(DateTime from, DateTime to);
}