namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class SilverColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Silver";
        public int? SignificantFigure => null;
        public decimal? Multiplier => (decimal?)0.01;
        public decimal? Tolerance => (decimal?)0.1;
    }
}
