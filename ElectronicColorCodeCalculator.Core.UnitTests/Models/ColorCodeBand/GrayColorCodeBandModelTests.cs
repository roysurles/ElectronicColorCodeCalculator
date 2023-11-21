﻿namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand;

public class GrayColorCodeBandModelTests : BaseColorCodeBandModelTest
{
    public GrayColorCodeBandModelTests(ITestOutputHelper output) : base(output) { }

    [Fact(DisplayName = "Class_PropertSettings_ShouldBe")]
    [Trait("Description", "Verify property settings based on: https://en.wikipedia.org/wiki/Electronic_color_code ")]
    [Trait("Category", "Unit")]
    public void Class_PropertSettings_ShouldBe()
    {
        // Arrange & Act
        var model = new GrayColorCodeBandModel();

        // Assert
        base.Class_PropertSettings_ShouldBe_BaseTest(model
            , "Gray"
            , 8
            , 100_000_000
            , (decimal?)0.0005);
    }
}
