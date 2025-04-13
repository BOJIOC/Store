namespace backendModuleV.Core.DTO.Import;

public class ImportResult
{
    public List<ImportedProductDto> NewProducts { get; set; } = new();
    public List<ImportedProductDto> UpdatedProducts { get; set; } = new();
    public List<ImportError> Errors { get; set; } = new();
}