namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class BlueColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Blue";
        public int? SignificantFigure => 6;
        public decimal? Multiplier => 1_000_000;
        public decimal? Tolerance => (decimal?)0.0025;
    }
}
