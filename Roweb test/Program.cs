using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Roweb_test.Data;
using Roweb_test.Models;
using System.Configuration;
using static Roweb_test.Models.SeedData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Roweb_testContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Roweb_testContext") ?? throw new InvalidOperationException("Connection string 'Roweb_testContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
