using BurgerAppRefactored.DataAccess;
using BurgerAppRefactored.DataAccess.Abstraction;
using BurgerAppRefactored.DataAccess.Repositories;
using BurgerAppRefactored.Domain;
using BurgerAppRefactored.Services.Abstraction;
using BurgerAppRefactored.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IBurgerService, BurgerService>();
builder.Services.AddTransient<IExtraService, ExtraService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IBurgerOrderItemService, BurgerOrderItemService>();
builder.Services.AddTransient<IExtraOrderItemService, ExtraOrderItemService>();

builder.Services.AddTransient<IRepository<Burger>, BurgerRepository>();
builder.Services.AddTransient<IRepository<Extra>, ExtraRepository>();
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
builder.Services.AddTransient<IRepository<BurgerOrderItem>, BurgerOrderItemRepository>();
builder.Services.AddTransient<IRepository<ExtraOrderItem>, ExtraOrderItemRepository>();

builder.Services.AddDbContext<BurgerAppRefactoredDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
app.Run();
