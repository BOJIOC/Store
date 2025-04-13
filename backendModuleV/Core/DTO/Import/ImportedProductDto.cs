namespace backendModuleV.Core.DTO.Import;

public class ImportedProductDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = "Unknown";
    public string Group { get; set; } = "General";
    public decimal Price { get; set; }
    public bool PriceChanged { get; set; }
}