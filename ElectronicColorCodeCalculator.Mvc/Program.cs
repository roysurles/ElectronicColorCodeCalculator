
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Models \ ColorCodeBand
var type = typeof(IColorCodeBandModel);
var types = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

builder.Services.AddTransient<IFourColorCodeBandsViewModel>((_) =>
    new FourColorCodeBandsViewModel(types.Select(Activator.CreateInstance).Cast<IColorCodeBandModel>().ToArray())
    as IFourColorCodeBandsViewModel);

// Calculators \ IOhmValueCalculator
builder.Services.AddTransient<IOhmValueCalculator, FourBandResistorCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
