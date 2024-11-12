using KoiShow.Repositories;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using KoiShow.Repositories.Repositories;
using KoiShow.Service.Interfaces;
using KoiShow.Service.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext với MySQL
builder.Services.AddDbContext<KoiShow2024Context>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("KoiShow2024"),
        new MySqlServerVersion(new Version(8, 0, 23)));
});

// Đăng ký các dịch vụ và repositories
builder.Services.AddScoped<IKoiShowAccountService, KoiShowAccountService>();
builder.Services.AddScoped<IKoiShowAccountRepository, KoiShowAccountRepository>();
builder.Services.AddScoped<IKoicategoryRepository, KoicategoryRepository>();
builder.Services.AddScoped<IKoicategoryService, KoicategoryService>();
builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();

// Cấu hình Razor Pages
builder.Services.AddRazorPages();

// Cấu hình session nếu cần thiết
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Đảm bảo session có thể hoạt động trong môi trường GDPR
});

// Cấu hình FormOptions nếu có yêu cầu upload file lớn
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10485760; // 10 MB
});

var app = builder.Build();

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

// Cấu hình để sử dụng session
app.UseRouting();

// Cấu hình session và authorization
app.UseSession(); // Đảm bảo gọi UseSession trước khi sử dụng các tính năng xác thực và bảo mật
app.UseAuthorization(); // Đảm bảo bạn sử dụng xác thực nếu cần

// Định tuyến Razor Pages
app.MapRazorPages();

// Chạy ứng dụng
app.Run();
