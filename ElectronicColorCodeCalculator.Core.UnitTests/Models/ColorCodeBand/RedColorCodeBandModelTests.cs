using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using Xunit;
using Xunit.Abstractions;

namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand
{
    public class RedColorCodeBandModelTests : BaseColorCodeBandModelTest
    {
        public RedColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

        [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
        [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
        [Trait("Category", "Unit")]
        public void Class_PropertSettings_ShouldBe()
        {
            // Arrange & Act
            var model = new RedColorCodeBandModel();

            // Assert
            base.Class_PropertSettings_ShouldBe_BaseTest(model
                , "Red"
                , 2
                , 100
                , (decimal?)0.02);
        }
    }
}
