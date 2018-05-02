using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using FluentAssertions;
using Xunit.Abstractions;

namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand
{
    public abstract class BaseColorCodeBandModelTest : BaseTest
    {
        protected BaseColorCodeBandModelTest(ITestOutputHelper output) : base(output) { }

        protected virtual void Class_PropertSettings_ShouldBe_BaseTest(IColorCodeBandModel colorCodeBandModel
            , string name, int? significantFigure, decimal? multiplier, decimal? tolerance)
        {
            colorCodeBandModel.Name.Should().Be(name);
            colorCodeBandModel.SignificantFigure.Should().Be(significantFigure);
            colorCodeBandModel.Multiplier.Should().Be(multiplier);
            colorCodeBandModel.Tolerance.Should().Be(tolerance);
        }
    }
}
