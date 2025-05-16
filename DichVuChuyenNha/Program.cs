using DichVuChuyenNha.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DichVuChuyenNhaContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Dbcontext")));
builder.Services.AddDistributedMemoryCache();  //  cho session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Th?i gian h?t h?n session
    options.Cookie.HttpOnly = true;  // B?o m?t cookie
    options.Cookie.IsEssential = true;  // Cookie b?t bu?c cho session
});
builder.Services.AddSession();

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("vi-VN"),
    SupportedCultures = new List<CultureInfo> { new CultureInfo("vi-VN") },
    SupportedUICultures = new List<CultureInfo> { new CultureInfo("vi-VN") }
});
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
