# IPB2.HotelBookingManagementSystem

A beginner-friendly multi-project .NET solution for a **Hotel Booking Management System**.

## Projects
- `IPB2.HotelBookingMS.Domain` - Entity classes only
- `IPB2.HotelBookingMS.Database` - ADO.NET services and SQL scripts
- `IPB2.HotelBookingMS.Console` - Menu-driven management console
- `IPB2.HotelBookingMS.WinForm` - Starter WinForms UI
- `IPB2.HotelBookingMS.WebApi` - REST API controllers
- `IPB2.HotelBookingMS.MinimalApi` - Minimal API endpoints
- `IPB2.HotelBookingMS.MVC` - ASP.NET Core MVC app
- `IPB2.HotelBookingMS.MVCwithHttpClient` - MVC app consuming Web API

## Requirements
- .NET 8 SDK
- SQL Server

## Run steps
1. Create database using script:
   - `IPB2.HotelBookingMS.Database/Scripts/hotel_booking_system.sql`
2. Update connection strings in all `appsettings.json` files.
3. Restore and build:
   - `dotnet restore`
   - `dotnet build`
4. Run any project:
   - `dotnet run --project IPB2.HotelBookingMS.Console`
   - `dotnet run --project IPB2.HotelBookingMS.WebApi`
   - `dotnet run --project IPB2.HotelBookingMS.MinimalApi`
   - `dotnet run --project IPB2.HotelBookingMS.MVC`
   - `dotnet run --project IPB2.HotelBookingMS.MVCwithHttpClient`

## Notes
- Connection strings use placeholders by default.
- Architecture is clean and simple for learning.

