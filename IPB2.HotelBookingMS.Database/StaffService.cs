using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class StaffService
{
    private readonly AdoDotNetService _adoService;

    public StaffService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<Staff> GetAll()
    {
        var items = new List<Staff>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("SELECT StaffId, FullName, Role, Phone FROM Staff", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new Staff
            {
                StaffId = reader.GetInt32(0),
                FullName = reader.GetString(1),
                Role = reader.GetString(2),
                Phone = reader.GetString(3)
            });
        }

        return items;
    }
}
