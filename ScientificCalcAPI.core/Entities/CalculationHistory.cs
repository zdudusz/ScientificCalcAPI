namespace ScientificCalcAPI.Core.Entities;

public class CalculationHistory
{
    public CalculationHistory(int userId, string operation, string parameters, decimal result)
    {
        UserId = userId;
        Operation = operation;
        Parameters = parameters;
        Result = result;
        CreatedAt = DateTime.Now;
    }
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Operation { get; set; } = null!;

    public string Parameters { get; set; } = null!;
    public User User { get; set; } = null!;

    public decimal Result { get; set; }

    public DateTime CreatedAt { get; set; }
}
