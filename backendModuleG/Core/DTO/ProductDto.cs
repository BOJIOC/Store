namespace backendModuleG.Core.DTO;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal? MinStock { get; set; }
    public decimal? MaxStock { get; set; }

}

