using ElectronicColorCodeCalculator.Core.Calculators.OhmValueCalculator;
using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
            // Models \ ColorCodeBand            
            var type = typeof(IColorCodeBandModel);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            services.AddTransient<IFourColorCodeBandsViewModel>((x) =>
                new FourColorCodeBandsViewModel(types.Select(Activator.CreateInstance).Cast<IColorCodeBandModel>().ToArray())
                as IFourColorCodeBandsViewModel);

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
