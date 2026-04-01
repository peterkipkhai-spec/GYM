using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class BookingService
{
    private readonly AdoDotNetService _adoService;

    public BookingService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<Booking> GetAll()
    {
        var items = new List<Booking>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("SELECT BookingId, RoomId, CustomerId, StaffId, CheckInDate, CheckOutDate, Status, CreatedDate FROM Bookings", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new Booking
            {
                BookingId = reader.GetInt32(0),
                RoomId = reader.GetInt32(1),
                CustomerId = reader.GetInt32(2),
                StaffId = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                CheckInDate = reader.GetDateTime(4),
                CheckOutDate = reader.GetDateTime(5),
                Status = reader.GetString(6),
                CreatedDate = reader.GetDateTime(7)
            });
        }

        return items;
    }

    public void CreateBooking(Booking booking)
    {
        using var connection = _adoService.CreateConnection();
        var sql = @"INSERT INTO Bookings (RoomId, CustomerId, StaffId, CheckInDate, CheckOutDate, Status)
                    VALUES (@RoomId, @CustomerId, @StaffId, @CheckInDate, @CheckOutDate, @Status)";
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@RoomId", booking.RoomId);
        command.Parameters.AddWithValue("@CustomerId", booking.CustomerId);
        command.Parameters.AddWithValue("@StaffId", (object?)booking.StaffId ?? DBNull.Value);
        command.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
        command.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
        command.Parameters.AddWithValue("@Status", booking.Status);
        connection.Open();
        command.ExecuteNonQuery();
    }

    public void CheckIn(int bookingId)
    {
        UpdateBookingStatus(bookingId, "CheckedIn");
    }

    public void CheckOut(int bookingId)
    {
        UpdateBookingStatus(bookingId, "CheckedOut");
    }

    private void UpdateBookingStatus(int bookingId, string status)
    {
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("UPDATE Bookings SET Status = @Status WHERE BookingId = @BookingId", connection);
        command.Parameters.AddWithValue("@Status", status);
        command.Parameters.AddWithValue("@BookingId", bookingId);
        connection.Open();
        command.ExecuteNonQuery();
    }
}
