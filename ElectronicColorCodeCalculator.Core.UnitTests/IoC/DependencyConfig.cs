using ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator;
using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ElectronicColorCodeCalculator.Core.UnitTests.IoC
{
    public static class DependencyConfig
    {
        public static Container BuildContainer()
        {
            var container = new Container();
            container.Options.SuppressLifestyleMismatchVerification = true;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Models \ ColorCodeBand
            container.Register<IFourColorCodeBandsViewModel>(() => new FourColorCodeBandsViewModel(
                new BlackColorCodeBandModel() as IColorCodeBandModel
                , new BlueColorCodeBandModel() as IColorCodeBandModel
                , new BrownColorCodeBandModel() as IColorCodeBandModel
                , new GoldColorCodeBandModel() as IColorCodeBandModel
                , new GrayColorCodeBandModel() as IColorCodeBandModel
                , new GreenColorCodeBandModel() as IColorCodeBandModel
                , new OrangeColorCodeBandModel() as IColorCodeBandModel
                , new PinkColorCodeBandModel() as IColorCodeBandModel
                , new RedColorCodeBandModel() as IColorCodeBandModel
                , new SilverColorCodeBandModel() as IColorCodeBandModel
                , new VioletColorCodeBandModel() as IColorCodeBandModel
                , new WhiteColorCodeBandModel() as IColorCodeBandModel
                , new YellowColorCodeBandModel() as IColorCodeBandModel
                ) as IFourColorCodeBandsViewModel, Lifestyle.Transient);

            // Calculators \ IOhmValueCalculator
            container.Register<IOhmValueCalculator, FourBandResistorCalculator>();

            // Optionally verify the container.
            container.Verify();

            return container;
        }
    }
}
