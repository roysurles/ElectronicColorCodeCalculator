namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class GoldColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Gold";
        public int? SignificantFigure => null;
        public decimal? Multiplier => (decimal?)0.1;
        public decimal? Tolerance => (decimal?)0.05;
    }
}
