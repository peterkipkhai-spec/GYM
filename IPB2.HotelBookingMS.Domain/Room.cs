namespace IPB2.HotelBookingMS.Domain;

public class Room
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public int RoomTypeId { get; set; }
    public bool IsActive { get; set; } = true;
    public string Status { get; set; } = "Available";
}
