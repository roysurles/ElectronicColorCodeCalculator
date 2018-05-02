namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class PinkColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Pink";
        public int? SignificantFigure => null;
        public decimal? Multiplier => (decimal?)0.001;
        public decimal? Tolerance => null;
    }
}
