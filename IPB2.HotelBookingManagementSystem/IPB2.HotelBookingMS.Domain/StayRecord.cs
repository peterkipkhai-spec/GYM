namespace IPB2.HotelBookingMS.Domain;

public class StayRecord
{
    public int StayRecordId { get; set; }
    public int BookingId { get; set; }
    public DateTime? ActualCheckIn { get; set; }
    public DateTime? ActualCheckOut { get; set; }
    public int TotalNights { get; set; }
}
