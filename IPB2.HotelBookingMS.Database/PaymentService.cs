using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class PaymentService
{
    private readonly AdoDotNetService _adoService;

    public PaymentService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<Payment> GetAll()
    {
        var items = new List<Payment>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("SELECT PaymentId, BookingId, Amount, PaymentMethod, PaymentDate, Notes FROM Payments", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new Payment
            {
                PaymentId = reader.GetInt32(0),
                BookingId = reader.GetInt32(1),
                Amount = reader.GetDecimal(2),
                PaymentMethod = reader.GetString(3),
                PaymentDate = reader.GetDateTime(4),
                Notes = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
            });
        }

        return items;
    }

    public void AcceptPayment(Payment payment)
    {
        using var connection = _adoService.CreateConnection();
        var sql = "INSERT INTO Payments (BookingId, Amount, PaymentMethod, PaymentDate, Notes) VALUES (@BookingId, @Amount, @PaymentMethod, @PaymentDate, @Notes)";
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@BookingId", payment.BookingId);
        command.Parameters.AddWithValue("@Amount", payment.Amount);
        command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
        command.Parameters.AddWithValue("@Notes", payment.Notes);
        connection.Open();
        command.ExecuteNonQuery();
    }
}
