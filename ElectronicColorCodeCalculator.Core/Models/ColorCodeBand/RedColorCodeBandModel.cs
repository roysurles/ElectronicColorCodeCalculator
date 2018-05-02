namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class RedColorCodeBandModel : IColorCodeBandModel
    {
        public string Name => "Red";
        public int? SignificantFigure => 2;
        public decimal? Multiplier => 100;
        public decimal? Tolerance => (decimal?)0.02;
    }
}
