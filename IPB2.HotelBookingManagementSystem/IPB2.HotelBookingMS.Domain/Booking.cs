namespace IPB2.HotelBookingMS.Domain;

public class Booking
{
    public int BookingId { get; set; }
    public int RoomId { get; set; }
    public int CustomerId { get; set; }
    public int? StaffId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; } = "Reserved";
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
