namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class VioletColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Violet";
        public int? SignificantFigure => 7;
        public decimal? Multiplier => 10_000_000;
        public decimal? Tolerance => (decimal?)0.001;
    }
}
