namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class YellowColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Yellow";
        public int? SignificantFigure => 4;
        public decimal? Multiplier => 10_000;
        public decimal? Tolerance => null;
    }
}
