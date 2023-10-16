//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using SnowCollegeHR.EmployeeManager.Data;

using Microsoft.EntityFrameworkCore;
using SnowCollegeHR.EmployeeManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<EmployeeManagerDBContext>(
    opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("EmployeeManagerDb")));

var app = builder.Build();

// this way is for development only, do not do it in production.
await EnsureDatabaseIsMigrated(app.Services);

async Task EnsureDatabaseIsMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<EmployeeManagerDBContext>();
    if (ctx is not null)
    {
        await ctx.Database.MigrateAsync();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
