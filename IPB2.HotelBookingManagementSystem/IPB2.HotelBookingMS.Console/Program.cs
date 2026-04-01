using IPB2.HotelBookingMS.Database;
using IPB2.HotelBookingMS.Domain;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var adoService = new AdoDotNetService(configuration);
var roomService = new RoomService(adoService);
var roomTypeService = new RoomTypeService(adoService);
var customerService = new CustomerService(adoService);
var staffService = new StaffService(adoService);
var bookingService = new BookingService(adoService);
var paymentService = new PaymentService(adoService);

var exit = false;
while (!exit)
{
    Console.WriteLine("\n=== Hotel Booking Management System ===");
    Console.WriteLine("1. Room Management");
    Console.WriteLine("2. Room Type Management");
    Console.WriteLine("3. Customer Management");
    Console.WriteLine("4. Staff Management");
    Console.WriteLine("5. Create Booking");
    Console.WriteLine("6. Check In");
    Console.WriteLine("7. Check Out");
    Console.WriteLine("8. Payment");
    Console.WriteLine("9. Reports");
    Console.WriteLine("0. Exit");
    Console.Write("Choose option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            foreach (var room in roomService.GetAll())
                Console.WriteLine($"{room.RoomId} - Room {room.RoomNumber} - {room.Status}");
            break;
        case "2":
            foreach (var roomType in roomTypeService.GetAll())
                Console.WriteLine($"{roomType.RoomTypeId} - {roomType.Name} - {roomType.PricePerNight:C}");
            break;
        case "3":
            foreach (var customer in customerService.GetAll())
                Console.WriteLine($"{customer.CustomerId} - {customer.FullName}");
            break;
        case "4":
            foreach (var staff in staffService.GetAll())
                Console.WriteLine($"{staff.StaffId} - {staff.FullName} ({staff.Role})");
            break;
        case "5":
            bookingService.CreateBooking(new Booking
            {
                RoomId = 1,
                CustomerId = 1,
                StaffId = 1,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(2),
                Status = "Reserved"
            });
            Console.WriteLine("Sample booking created.");
            break;
        case "6":
            bookingService.CheckIn(1);
            Console.WriteLine("Booking 1 checked in.");
            break;
        case "7":
            bookingService.CheckOut(1);
            Console.WriteLine("Booking 1 checked out.");
            break;
        case "8":
            paymentService.AcceptPayment(new Payment
            {
                BookingId = 1,
                Amount = 100,
                PaymentMethod = "Cash",
                Notes = "Console payment"
            });
            Console.WriteLine("Payment recorded.");
            break;
        case "9":
            Console.WriteLine("Reports available in Web API/Minimal API and SQL views.");
            break;
        case "0":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
