using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using Xunit;
using Xunit.Abstractions;

namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand
{
    public class BrownColorCodeBandModelTests : BaseColorCodeBandModelTest
    {
        public BrownColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

        [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
        [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
        [Trait("Category", "Unit")]
        public void Class_PropertSettings_ShouldBe()
        {
            // Arrange & Act
            var model = new BrownColorCodeBandModel();

            // Assert
            base.Class_PropertSettings_ShouldBe_BaseTest(model
                , "Brown"
                , 1
                , 10
                , (decimal?)0.01);
        }
    }
}
