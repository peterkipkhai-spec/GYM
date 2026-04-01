using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class CustomerService
{
    private readonly AdoDotNetService _adoService;

    public CustomerService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<Customer> GetAll()
    {
        var items = new List<Customer>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("SELECT CustomerId, FullName, Phone, Email, IdNumber FROM Customers", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new Customer
            {
                CustomerId = reader.GetInt32(0),
                FullName = reader.GetString(1),
                Phone = reader.GetString(2),
                Email = reader.GetString(3),
                IdNumber = reader.GetString(4)
            });
        }

        return items;
    }
}
