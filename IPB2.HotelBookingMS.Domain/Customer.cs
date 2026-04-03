namespace IPB2.HotelBookingMS.Domain;

public class Customer
{
    public int CustomerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string IdNumber { get; set; } = string.Empty;
}
