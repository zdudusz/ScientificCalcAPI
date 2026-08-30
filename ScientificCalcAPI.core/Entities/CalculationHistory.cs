namespace ScientificCalcAPI.Core.Entities;

public class CalculationHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Operation { get; set; } = null!;

    public string Parameters { get; set; } = null!;

    public decimal Result { get; set; }

    public DateTime CreatedAt { get; set; }
}
