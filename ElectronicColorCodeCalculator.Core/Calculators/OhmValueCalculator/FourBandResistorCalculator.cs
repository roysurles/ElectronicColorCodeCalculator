using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using System;
using System.Linq;

namespace ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator
{
    public class FourBandResistorCalculator : IOhmValueCalculator
    {
        private readonly IFourColorCodeBandsViewModel _colorCodeBandsViewModel;

        public FourBandResistorCalculator(IFourColorCodeBandsViewModel colorCodeBandsViewModel) =>
            _colorCodeBandsViewModel = colorCodeBandsViewModel;

        public decimal? CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            // validation: the first 3 bands are required for calculation
            if (string.IsNullOrWhiteSpace(bandAColor) || string.IsNullOrWhiteSpace(bandBColor) || string.IsNullOrWhiteSpace(bandCColor))
                return null;

            // try to get each band's color
            var bandAcolor = _colorCodeBandsViewModel.BandAAvailableColors.FirstOrDefault(x => Equals(x.Name, bandAColor));
            var bandBcolor = _colorCodeBandsViewModel.BandBAvailableColors.FirstOrDefault(x => Equals(x.Name, bandBColor));
            var bandCcolor = _colorCodeBandsViewModel.BandCAvailableColors.FirstOrDefault(x => Equals(x.Name, bandCColor));
            var bandDcolor = string.IsNullOrWhiteSpace(bandDColor)
                ? default(IColorCodeBandModel)
                : _colorCodeBandsViewModel.BandDAvailableColors.FirstOrDefault(x => Equals(x.Name, bandDColor));

            // validation: check the first 3 bands are available in corresponding bands 
            // the 4'th band is optional so, only check the 4th band if it was supplied
            if (bandAcolor == null || bandBcolor == null || bandCcolor == null
                || (!string.IsNullOrWhiteSpace(bandDColor) && bandDcolor == null))
            {
                return null;
            }

            var significantFigures = string.Concat(bandAcolor.SignificantFigure, bandBcolor.SignificantFigure);
            var significantFiguresAsInt = Convert.ToInt32(significantFigures);

            return significantFiguresAsInt * bandCcolor.Multiplier;
        }
    }
}
