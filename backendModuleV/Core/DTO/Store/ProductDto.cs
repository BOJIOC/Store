namespace backendModuleV.Core.DTO.Store;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
}