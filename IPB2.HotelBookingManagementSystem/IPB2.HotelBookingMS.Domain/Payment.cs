namespace IPB2.HotelBookingMS.Domain;

public class Payment
{
    public int PaymentId { get; set; }
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = "Cash";
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string Notes { get; set; } = string.Empty;
}
