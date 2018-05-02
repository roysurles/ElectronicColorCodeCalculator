using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicColorCodeCalculator.Core.Models.ColorCodeBand
{
    public class FourColorCodeBandsViewModel : IFourColorCodeBandsViewModel
    {
        public FourColorCodeBandsViewModel(params IColorCodeBandModel[] colorCodeBandModels)
        {
            if (colorCodeBandModels.Any(x => string.IsNullOrWhiteSpace(x.Name)))
                throw new ArgumentNullException("colorCodeBandModel.Name", "colorCodeBandModel.Name cannot be null or empty string.");

            BandAAvailableColors = colorCodeBandModels
                .Where(x => x.SignificantFigure.HasValue && x.SignificantFigure > 0)
                .OrderBy(x => x.SignificantFigure);

            BandBAvailableColors = colorCodeBandModels
                .Where(x => x.SignificantFigure.HasValue)
                .OrderBy(x => x.SignificantFigure);

            BandCAvailableColors = colorCodeBandModels
                .Where(x => x.Multiplier.HasValue)
                .OrderBy(x => x.Multiplier);

            BandDAvailableColors = colorCodeBandModels
                .Where(x => x.Tolerance.HasValue)
                .OrderBy(x => x.Tolerance);
        }

        public IEnumerable<IColorCodeBandModel> BandAAvailableColors { get; }
        public IEnumerable<IColorCodeBandModel> BandBAvailableColors { get; }
        public IEnumerable<IColorCodeBandModel> BandCAvailableColors { get; }
        public IEnumerable<IColorCodeBandModel> BandDAvailableColors { get; }
    }

    /// <summary>
    /// Represents available colors for four bands.
    /// </summary>
    public interface IFourColorCodeBandsViewModel
    {
        /// <summary>
        /// All IColorCodeBandModels available for Band A.
        /// </summary>
        IEnumerable<IColorCodeBandModel> BandAAvailableColors { get; }
        /// <summary>
        /// All IColorCodeBandModels available for Band B.
        /// </summary>
        IEnumerable<IColorCodeBandModel> BandBAvailableColors { get; }
        /// <summary>
        /// All IColorCodeBandModels available for Band C.
        /// </summary>
        IEnumerable<IColorCodeBandModel> BandCAvailableColors { get; }
        /// <summary>
        /// All IColorCodeBandModels available for Band D.
        /// </summary>
        IEnumerable<IColorCodeBandModel> BandDAvailableColors { get; }
    }
}
