namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class WhiteColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "White";
        public int? SignificantFigure => 9;
        public decimal? Multiplier => 1_000_000_000;
        public decimal? Tolerance => null;
    }
}
