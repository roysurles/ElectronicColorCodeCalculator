namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class GreenColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Green";
        public int? SignificantFigure => 5;
        public decimal? Multiplier => 100_000;
        public decimal? Tolerance => (decimal?)0.005;
    }
}
