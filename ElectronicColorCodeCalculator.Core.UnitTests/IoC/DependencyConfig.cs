using ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator;
using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var excludedClassNames = new List<string> { "NoNameColorCodeBandModel" };
            var type = typeof(IColorCodeBandModel);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !excludedClassNames.Contains(p.Name));

            container.Register<IFourColorCodeBandsViewModel>(() =>
                new FourColorCodeBandsViewModel(types.Select(Activator.CreateInstance).Cast<IColorCodeBandModel>().ToArray())
                as IFourColorCodeBandsViewModel, Lifestyle.Transient);

            // Calculators \ IOhmValueCalculator
            container.Register<IOhmValueCalculator, FourBandResistorCalculator>();

            // Optionally verify the container.
            container.Verify();

            return container;
        }
    }
}
