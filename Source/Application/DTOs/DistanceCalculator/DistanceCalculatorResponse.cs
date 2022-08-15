using Application.Enums;
using DataModel;
using DataModel.Measures;

namespace Application.DTOs
{
    public class DistanceCalculatorResult
    {
        public double Distance { get; set; }

        public Measure Measure { get; set; }
    }
}
