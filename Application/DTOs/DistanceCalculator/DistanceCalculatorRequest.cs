using Application.Enums;
using DataModel;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DistanceCalculatorRequest
    {
        [Required]
        public GeoCoordinate FirstCoordinate { get; set; }
        
        [Required]
        public GeoCoordinate SecondCoordinate { get; set; }

        public MeasuringUnit? MeasuringUnit { get; set; }
    }
}
