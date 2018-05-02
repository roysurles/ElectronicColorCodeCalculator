using ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator;
using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicColorCodeCalculator.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: there is probably a slick way to get all concrete classes
            // that implement IColorCodeBandModel and inject as an array

            // Models \ ColorCodeBand            
            services.AddTransient<IFourColorCodeBandsViewModel>((x) =>
                new FourColorCodeBandsViewModel(
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
                ) as IFourColorCodeBandsViewModel);

            // Calculators \ IOhmValueCalculator
            services.AddTransient<IOhmValueCalculator, FourBandResistorCalculator>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
