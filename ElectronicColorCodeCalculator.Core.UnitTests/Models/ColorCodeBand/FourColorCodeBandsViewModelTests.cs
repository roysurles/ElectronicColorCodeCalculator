namespace ElectronicColorCodeCalculator.Core.UnitTests.Models.ColorCodeBand;

public class FourColorCodeBandsViewModelTests : BaseTest
{
    public FourColorCodeBandsViewModelTests(ITestOutputHelper output) : base(output) { }

    [Fact(DisplayName = "Ctor_MissingNameColorCodeBandModel_ShouldThrowException")]
    [Trait("Description", "Verify ctor throws exception if any items are missing the name")]
    [Trait("Category", "Unit")]
    public void Ctor_MissingNameColorCodeBandModel_ShouldThrowException()
    {
        // Arrange
        Action action = () => new FourColorCodeBandsViewModel(new NoNameColorCodeBandModel());

        // Act & Assert
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact(DisplayName = "Ctor_Duplicates_ShouldThrowException")]
    [Trait("Description", "Verify ctor throws exception if any items are duplicated on name")]
    [Trait("Category", "Unit")]
    public void Ctor_Duplicates_ShouldThrowException()
    {
        // Arrange
        Action action = () => new FourColorCodeBandsViewModel(new BlackColorCodeBandModel(), new BlackColorCodeBandModel());

        // Act & Assert
        action.Should().Throw<InvalidOperationException>();
    }
}

public class NoNameColorCodeBandModel : IColorCodeBandModel
{
    public string Name => null;
    public int? SignificantFigure => null;
    public decimal? Multiplier => null;
    public decimal? Tolerance => null;
}
