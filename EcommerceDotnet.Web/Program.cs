using EcommerceDotnet.Data;
using EcommerceDotnet.Services;
using EcommerceDotnet.Web.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EcommerceContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceContext")));// ?? throw new InvalidOperationException("Connection string 'BWIJAN20WEBContext' not found.")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<MySession>();

builder.Services.AddTransient<IShopService, ShopService>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IAccountService, AccountService>();



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
