using DataModel.GeometricFigures;

namespace DataModel.Measures
{
    public class GeometricFigureMeasure
    {
        public int Id { get; set; }

        public GeometricFigure GeometricFigure { get; set; }

        public Measure Measure { get; set; }

        public double Distance { get; set; }
    }
}
