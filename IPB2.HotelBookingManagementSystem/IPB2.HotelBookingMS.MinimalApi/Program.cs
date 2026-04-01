using IPB2.HotelBookingMS.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AdoDotNetService>();
builder.Services.AddScoped<RoomTypeService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<StaffService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();

app.MapGet("/api/room-types", (RoomTypeService service) => service.GetAll());
app.MapGet("/api/rooms", (RoomService service) => service.GetAll());
app.MapGet("/api/customers", (CustomerService service) => service.GetAll());
app.MapGet("/api/staff", (StaffService service) => service.GetAll());
app.MapGet("/api/bookings", (BookingService service) => service.GetAll());
app.MapGet("/api/payments", (PaymentService service) => service.GetAll());

app.MapGet("/api/reports/booking", (ReportService service) => service.GetReport("vw_BookingReport"));
app.MapGet("/api/reports/room-availability", (ReportService service) => service.GetReport("vw_RoomAvailabilityReport"));
app.MapGet("/api/reports/customer-stay-summary", (ReportService service) => service.GetReport("vw_CustomerStaySummary"));

app.Run();
