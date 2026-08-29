using System;
using System.Collections.Generic;

namespace ScientificCalculatorApi.Infraestructure.Scaffold;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CalculationHistory> CalculationHistories { get; set; } = new List<CalculationHistory>();
}
