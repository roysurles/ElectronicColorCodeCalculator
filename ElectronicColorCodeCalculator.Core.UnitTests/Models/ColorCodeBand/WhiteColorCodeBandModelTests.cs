namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand;

public class WhiteColorCodeBandModelTests : BaseColorCodeBandModelTest
{
    public WhiteColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

    [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
    [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
    [Trait("Category", "Unit")]
    public void Class_PropertSettings_ShouldBe()
    {
        // Arrange & Act
        var model = new WhiteColorCodeBandModel();

        // Assert
        base.Class_PropertSettings_ShouldBe_BaseTest(model
            , "White"
            , 9
            , 1_000_000_000
            , null);
    }
}
