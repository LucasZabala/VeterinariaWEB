using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Veterinaria.Logic.Data;
using Veterinaria.Logic.Interfaces;
using Veterinaria.Logic.Repository;
using Veterinaria.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VeterinariaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDuenoRepository, DuenoRepository>();
builder.Services.AddScoped<IDuenoService, DuenoService>();

var app = builder.Build();

////////////////////////// Agrega aquí la configuración de la cultura ///////////////////////////
var cultureInfo = new CultureInfo("es-AR"); // O el código de tu región
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
cultureInfo.NumberFormat.NumberGroupSeparator = ",";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
////////////////////////////////////////////////////////////////////////////////////////////////

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
