namespace backendModuleG.Core.Entities;

public enum PromotionType
{
    ProductDiscount,
    CheckAmountDiscount,
    TimeDiscount
}

public class Promotion
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public PromotionType Type { get; set; }

    // Применимо к товарам
    public List<int>? ProductIds { get; set; }

    // Применимо к сумме чека
    public decimal? MinCheckAmount { get; set; }

    // Применимо ко времени
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    public decimal DiscountPercent { get; set; }
}