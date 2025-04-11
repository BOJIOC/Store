namespace Courier.SharedModels;

public class EmployeeDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Position { get; set; } = "";
    public int StoreId { get; set; }
}