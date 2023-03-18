using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(option=> { option.IdleTimeout = TimeSpan.FromHours(1); });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoginManagement, LoginManagement>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductManagement, ProductManagement>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartManagement, CartManagement>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cart}/{action=Index}");

app.Run();
