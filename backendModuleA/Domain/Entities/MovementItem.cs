namespace backendModuleA.Domain.Entities;

public class MovementItem
{
    public int Id { get; set; }

    public int MovementId { get; set; }
    public Movement Movement { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}