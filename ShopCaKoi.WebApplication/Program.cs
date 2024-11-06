using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Services;
using ShopCaKoi.Sevices;
using ShopCaKoi.Sevices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataShopCaKoiContext>();
//DI Repository
builder.Services.AddScoped<IShopCaKoiAccountRepository, ShopCaKoiAccountRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IKoiRepository, KoiRepository>();
builder.Services.AddScoped<IKoiFarmRepository, KoiFarmRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//DI Service
builder.Services.AddScoped<IShopCaKoiAccountService, ShopCaKoiAccountService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddScoped<IKoiFarmService, KoiFarmService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();