using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shopping.Web.Models;
using Stripe;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromHours(1); });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoginManagement, LoginManagement>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductManagement, ProductManagement>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartManagement, CartManagement>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteManagement, FavoriteManagement>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryManagement, CategoryManagement>();
builder.Services.AddScoped<IUserManagement, UserManagement>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDeliveryItemRepository, DeliveryItemRepository>();
builder.Services.AddScoped<IDeliveryManagement, DeliveryManagement>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// category sessionu view'a göndermek için

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = "sk_test_51MV9XKGf2R9IM47QqGkjHZiIzr8vvHpbXpP23MNxsVthyoY8lc91qGUkLeFJ5njzP7w3UaqgfkLTUbeCnCxFQNFI00SVwTEL5Z";

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
    pattern: "{controller=Login}/{action=Index}");

app.Run();
