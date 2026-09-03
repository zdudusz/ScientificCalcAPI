using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.DTOs
{
    public class CalculationRequestDto
    {
        public string Operation { get; set; }
        public List<double> Operands { get; set; }
    }
}
