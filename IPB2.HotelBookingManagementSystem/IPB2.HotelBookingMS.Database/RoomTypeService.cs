using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class RoomTypeService
{
    private readonly AdoDotNetService _adoService;

    public RoomTypeService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<RoomType> GetAll()
    {
        var items = new List<RoomType>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("SELECT RoomTypeId, Name, PricePerNight, Capacity, Description FROM RoomTypes", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new RoomType
            {
                RoomTypeId = reader.GetInt32(0),
                Name = reader.GetString(1),
                PricePerNight = reader.GetDecimal(2),
                Capacity = reader.GetInt32(3),
                Description = reader.IsDBNull(4) ? null : reader.GetString(4)
            });
        }

        return items;
    }
}
