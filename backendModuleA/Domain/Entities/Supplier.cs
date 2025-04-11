namespace backendModuleA.Domain.Entities;

public class Supplier
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;
}