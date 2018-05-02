namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class OrangeColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Orange";
        public int? SignificantFigure => 3;
        public decimal? Multiplier => 1_000;
        public decimal? Tolerance => null;
    }
}
