namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand;

public class YellowColorCodeBandModelTests : BaseColorCodeBandModelTest
{
    public YellowColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

    [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
    [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
    [Trait("Category", "Unit")]
    public void Class_PropertSettings_ShouldBe()
    {
        // Arrange & Act
        var model = new YellowColorCodeBandModel();

        // Assert
        base.Class_PropertSettings_ShouldBe_BaseTest(model
            , "Yellow"
            , 4
            , 10_000
            , null);
    }
}
