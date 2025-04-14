namespace backendModuleG.Core.Models;

public class LabelDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal FinalPrice { get; set; }
    public bool HasDiscount { get; set; }
    public byte[] QrCodeImage { get; set; } = [];
}