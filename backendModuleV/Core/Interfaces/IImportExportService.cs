using backendModuleV.Core.DTO.Import;

namespace backendModuleV.Core.Interfaces;

public interface IImportExportService
{
    Task<ImportResult> CheckPriceListsAsync(string directoryPath, decimal? priceIncrease);
    Task<ImportResult> ImportPriceListsAsync(string directoryPath, decimal? priceIncrease);
    Task ExportProductsAsync(string targetDirectory);
}