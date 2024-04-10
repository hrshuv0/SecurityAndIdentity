using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomUserIdentityApp.Data;
using CustomUserIdentityApp.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CustomUserIdentityAppContextConnection") ?? throw new InvalidOperationException("Connection string 'CustomUserIdentityAppContextConnection' not found.");

builder.Services.AddDbContext<CustomUserIdentityAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CustomAppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CustomUserIdentityAppContext>();

builder.Services.AddRazorPages();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
