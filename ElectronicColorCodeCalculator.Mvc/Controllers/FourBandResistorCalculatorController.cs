namespace ElectronicColorCodeCalculator.Mvc.Controllers;

public class FourBandResistorCalculatorController : Controller
{
    [HttpGet]
    public IActionResult Index([FromServices] IFourColorCodeBandsViewModel viewModel) =>
        View(viewModel);

    [HttpPost]
    public IActionResult Calculate(string bandAColor, string bandBColor, string bandCColor, string bandDColor
        , [FromServices] IOhmValueCalculator fourBandResistorCalculator
        , [FromServices] IFourColorCodeBandsViewModel fourColorCodeBandsViewModel) =>
            Json(fourBandResistorCalculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor)
                .ToFormattedOhms(bandDColor, fourColorCodeBandsViewModel));
}
