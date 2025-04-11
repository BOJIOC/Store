namespace backendModuleA.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;
}