using ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator;
using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using ElectronicColorCodeCalculator.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicColorCodeCalculator.Mvc.Controllers
{
    public class FourBandResistorCalculatorController : Controller
    {
        private readonly IOhmValueCalculator _fourBandResistorCalculator;

        public FourBandResistorCalculatorController(IOhmValueCalculator fourBandResistorCalculator) =>
            _fourBandResistorCalculator = fourBandResistorCalculator;

        [HttpGet]
        public IActionResult Index([FromServices] IFourColorCodeBandsViewModel viewModel) =>
            View(viewModel);

        [HttpPost]
        public IActionResult Calculate(string bandAColor, string bandBColor, string bandCColor, string bandDColor) =>
            Json(_fourBandResistorCalculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor)
                .ToFormattedOhms(bandDColor, HttpContext.RequestServices.GetService(typeof(IFourColorCodeBandsViewModel)) as IFourColorCodeBandsViewModel));
    }
}
