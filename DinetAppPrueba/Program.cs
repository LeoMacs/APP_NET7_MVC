using DinetAppPrueba.BussinessLogic.interfaces;
using DinetAppPrueba.BussinessLogic.services;
using DinetAppPrueba.DataAccess.Data;
using DinetAppPrueba.DataAccess.implementacion;
using DinetAppPrueba.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//////////////////////////////////////
builder.Services.AddSingleton<ConexionService>();
//////////////////////////////////////
builder.Services.AddSingleton<IMovimientosService, MovimientosService>();
builder.Services.AddSingleton<IMovimientos, MovimientosDA>();

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
    pattern: "{controller=Movimiento}/{action=panelMovimientos}/{id?}");

app.Run();
