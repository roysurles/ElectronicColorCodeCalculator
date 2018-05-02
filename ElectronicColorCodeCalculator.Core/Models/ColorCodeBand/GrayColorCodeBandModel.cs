namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class GrayColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Gray";
        public int? SignificantFigure => 8;
        public decimal? Multiplier => 100_000_000;
        public decimal? Tolerance => (decimal?)0.0005;
    }
}
