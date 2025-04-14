using backendModuleG.Core.Models;

namespace backendModuleG.Core.Interfaces;

public interface ILabelService
{
    Task<List<LabelDto>> GenerateLabelsAsync(List<int> productIds, bool includeMarketing);
}