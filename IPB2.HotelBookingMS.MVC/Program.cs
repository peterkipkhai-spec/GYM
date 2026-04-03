using IPB2.HotelBookingMS.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AdoDotNetService>();
builder.Services.AddScoped<RoomTypeService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<StaffService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
