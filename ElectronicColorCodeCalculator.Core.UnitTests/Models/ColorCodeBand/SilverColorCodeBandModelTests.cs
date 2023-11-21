namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand;

public class SilverColorCodeBandModelTests : BaseColorCodeBandModelTest
{
    public SilverColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

    [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
    [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
    [Trait("Category", "Unit")]
    public void Class_PropertSettings_ShouldBe()
    {
        // Arrange & Act
        var model = new SilverColorCodeBandModel();

        // Assert
        base.Class_PropertSettings_ShouldBe_BaseTest(model
            , "Silver"
            , null
            , (decimal?)0.01
            , (decimal?)0.1);
    }
}
