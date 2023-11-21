namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand;

public class GreenColorCodeBandModelTests : BaseColorCodeBandModelTest
{
    public GreenColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

    [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
    [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
    [Trait("Category", "Unit")]
    public void Class_PropertSettings_ShouldBe()
    {
        // Arrange & Act
        var model = new GreenColorCodeBandModel();

        // Assert
        base.Class_PropertSettings_ShouldBe_BaseTest(model
            , "Green"
            , 5
            , 100_000
            , (decimal?)0.005);
    }
}
