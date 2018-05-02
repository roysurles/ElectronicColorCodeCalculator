namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    /// <summary>
    /// Represents the data elements for a color code band of a resistor.
    /// <seealso cref="https://en.wikipedia.org/wiki/Electronic_color_code"/>
    /// </summary>
    public interface IColorCodeBandModel
    {
        /// <summary>
        /// Name of the color code band. Also indicates the color of the band.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The significant figure of component value.
        /// </summary>
        int? SignificantFigure { get; }
        /// <summary>
        /// The decimal multiplier (number of trailing zeroes).
        /// </summary>
        decimal? Multiplier { get; }
        /// <summary>
        /// If present, indicates tolerance of value in percent (no band means 20%)
        /// </summary>
        decimal? Tolerance { get; }
    }
}
