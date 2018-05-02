namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class BrownColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Brown";
        public int? SignificantFigure => 1;
        public decimal? Multiplier => 10;
        public decimal? Tolerance => (decimal?)0.01;
    }
}
