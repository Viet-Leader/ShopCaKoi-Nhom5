using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Services;
using ShopCaKoi.Sevices.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Sevices;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ vào container

// Thêm Razor Pages
builder.Services.AddRazorPages();

// Cấu hình DbContext cho Entity Framework Core
builder.Services.AddDbContext<DataShopCaKoiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký DI cho các Repository
builder.Services.AddScoped<IShopCaKoiAccountRepository, ShopCaKoiAccountRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IKoiRepository, KoiRepository>();
builder.Services.AddScoped<IKoiFarmRepository, KoiFarmRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Đăng ký DI cho các Service
builder.Services.AddScoped<IShopCaKoiAccountService, ShopCaKoiAccountService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddScoped<IKoiFarmService, KoiFarmService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Thêm hỗ trợ Session cho ứng dụng
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Thời gian timeout
    options.Cookie.HttpOnly = true;                  // Chỉ cho phép truy cập cookie thông qua HTTP
    options.Cookie.IsEssential = true;               // Đảm bảo cookie session không bị chặn
});

// Cấu hình CORS để cho phép truy cập từ tất cả các nguồn gốc (origin)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()   // Cho phép tất cả các origin (domain)
               .AllowAnyMethod()   // Cho phép tất cả các method (GET, POST, PUT, DELETE...)
               .AllowAnyHeader();  // Cho phép tất cả các header
    });

    // Cấu hình CORS cho một domain cụ thể (nếu cần)
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:5000")  // Chỉ cho phép một domain cụ thể
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Cấu hình pipeline HTTP request

// Điều kiện khi không ở môi trường phát triển (Development)
if (!app.Environment.IsDevelopment())
{
    // Xử lý lỗi với middleware ExceptionHandler
    app.UseExceptionHandler("/Error");
    app.UseHsts();  // Sử dụng HTTP Strict Transport Security (HSTS)
}

// Sử dụng các tệp mặc định và tệp tĩnh
app.UseDefaultFiles();
app.UseStaticFiles();

// Chuyển hướng HTTP sang HTTPS
app.UseHttpsRedirection();

// Cấu hình Routing
app.UseRouting();  // Đặt app.UseRouting() trước khi sử dụng CORS và session

// Sử dụng CORS với policy "AllowAll" để cho phép tất cả các nguồn gốc
app.UseCors("AllowAll");  // Đặt sau app.UseRouting() nhưng trước app.UseAuthorization()

// Sử dụng Authorization nếu có (có thể bỏ qua nếu ứng dụng không có yêu cầu xác thực)
app.UseAuthorization();

// Sử dụng session cho ứng dụng
app.UseSession();

// Chạy Razor Pages và API Controllers
app.MapRazorPages();  // Sử dụng Razor Pages
app.MapControllers();  // Đảm bảo API controllers có thể được gọi

// Chạy ứng dụng
app.Run();