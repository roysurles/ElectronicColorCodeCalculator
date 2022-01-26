using ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;

namespace ElectronicColorCodeCalculator.Core.UnitTests.Calculators.OhmValueCalculator
{
    public class FourBandResistorCalculatorTests : BaseTest
    {
        public FourBandResistorCalculatorTests(ITestOutputHelper output) : base(output) { }

        [Theory(DisplayName = "CalculateOhmValue_MissingInput_ShouldReturnNull")]
        [Trait("Description", "Verify CalculateOhmValue does not throw exception for bad input")]
        [Trait("Category", "Unit")]
        [InlineData(null, null, null, null)]
        [InlineData("", "", "", "")]
        [InlineData("Brown", null, null, null)]
        [InlineData("Brown", "", "", "")]
        [InlineData(null, "Brown", null, null)]
        [InlineData("", "Brown", "", "")]
        [InlineData(null, null, "Brown", null)]
        [InlineData("", "", "Brown", "")]
        [InlineData(null, null, null, "Brown")]
        [InlineData("", "", "", "Brown")]
        public void CalculateOhmValue_MissingInput_ShouldReturnNull(
            string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            // Arrange
            var calculator = Container.GetInstance<IOhmValueCalculator>();

            // Act
            var result = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            // Assert
            result.Should().Be(null);
        }

        [Theory(DisplayName = "CalculateOhmValue_InvalidInput_ShouldReturnNull")]
        [Trait("Description", "Verify CalculateOhmValue does not throw exception for bad input")]
        [Trait("Category", "Unit")]
        [InlineData("Black", "Red", "Red", "Red")]
        [InlineData("Brown", "Gold", "Red", "Red")]
        [InlineData("Brown", "Red", "Red", "Black")]
        public void CalculateOhmValue_InvalidInput_ShouldReturnNull(
            string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            // Arrange
            var calculator = Container.GetInstance<IOhmValueCalculator>();

            // Act
            var result = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            // Assert
            result.Should().Be(null);
        }

        [Theory(DisplayName = "CalculateOhmValue_SignificantFigures_ShouldBeCorrect")]
        [Trait("Description", "Verify CalculateOhmValue calculates SignificantFigures correctly")]
        [Trait("Category", "Unit")]
        [InlineData("Brown", "Brown", "Black", null, 11)]
        [InlineData("Brown", "Yellow", "Black", null, 14)]
        [InlineData("Brown", "White", "Black", null, 19)]
        [InlineData("Green", "Black", "Black", null, 50)]
        [InlineData("Green", "Green", "Black", null, 55)]
        [InlineData("Green", "White", "Black", null, 59)]
        public void CalculateOhmValue_SignificantFigures_ShouldBeCorrect(
            string bandAColor, string bandBColor, string bandCColor, string bandDColor, int expectedResult)
        {
            // Arrange
            var calculator = Container.GetInstance<IOhmValueCalculator>();

            // Act
            var result = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory(DisplayName = "CalculateOhmValue_Multiplier_ShouldBeCorrect")]
        [Trait("Description", "Verify CalculateOhmValue calculates Multiplier correctly")]
        [Trait("Category", "Unit")]
        [InlineData("White", "White", "Black", null, 99)]
        [InlineData("White", "White", "Brown", null, 990)]
        [InlineData("White", "White", "Red", null, 9900)]
        [InlineData("White", "White", "Orange", null, 99_000)]
        [InlineData("White", "White", "Yellow", null, 990_000)]
        [InlineData("White", "White", "Green", null, 9_900_000)]
        [InlineData("White", "White", "Blue", null, 99_000_000)]
        [InlineData("White", "White", "Violet", null, 990_000_000)]
        [InlineData("White", "White", "Gray", null, 9_900_000_000)]
        [InlineData("White", "White", "White", null, 99_000_000_000)]   // int.Max = 2,147,483,647
        [InlineData("White", "White", "Gold", null, 9.9)]               // decimal instead of int
        [InlineData("White", "White", "Silver", null, 0.99)]            // decimal instead of int
        public void CalculateOhmValue_Multiplier_ShouldBeCorrect(
            string bandAColor, string bandBColor, string bandCColor, string bandDColor, decimal expectedResult)
        {
            // Arrange
            var calculator = Container.GetInstance<IOhmValueCalculator>();

            // Act
            var result = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
