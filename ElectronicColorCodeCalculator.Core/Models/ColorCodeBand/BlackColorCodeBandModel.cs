namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class BlackColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Black";
        public int? SignificantFigure => 0;
        public decimal? Multiplier => 1;
        public decimal? Tolerance => null;
    }
}
