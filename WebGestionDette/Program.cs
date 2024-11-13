using Microsoft.EntityFrameworkCore;
using WebGestionDette.Data;
using WebGestionDette.Data.Fixtures;
using WebGestionDette.Models.Impl;
using WebGestionDette.Service;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("PostgresConnection")!;

builder.Services.AddDbContext<WebGesDetteContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ClientFixtures>();
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<WebGesDetteContext>();
//     var clientFixtures = scope.ServiceProvider.GetRequiredService<ClientFixtures>();
    
//     // Charger les données si nécessaire
//     clientFixtures.LoadData();
// }

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
