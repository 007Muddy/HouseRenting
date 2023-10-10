using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HouseRenting.Data;
using HouseRenting.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'HouseRentingContextConnection' not found.");

builder.Services.AddDbContext<HouseDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Razor Pages services
builder.Services.AddRazorPages();

var app = builder.Build();

// Seed the data when the application starts
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    SeedData.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Houses}/{action=Index}/{id?}");

app.Run();
