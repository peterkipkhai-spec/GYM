using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class RoomService
{
    private readonly AdoDotNetService _adoService;

    public RoomService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<Room> GetAll()
    {
        var items = new List<Room>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand("SELECT RoomId, RoomNumber, RoomTypeId, IsActive, Status FROM Rooms", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new Room
            {
                RoomId = reader.GetInt32(0),
                RoomNumber = reader.GetString(1),
                RoomTypeId = reader.GetInt32(2),
                IsActive = reader.GetBoolean(3),
                Status = reader.GetString(4)
            });
        }

        return items;
    }

    public void Add(Room room)
    {
        using var connection = _adoService.CreateConnection();
        var sql = "INSERT INTO Rooms (RoomNumber, RoomTypeId, IsActive, Status) VALUES (@RoomNumber, @RoomTypeId, @IsActive, @Status)";
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
        command.Parameters.AddWithValue("@RoomTypeId", room.RoomTypeId);
        command.Parameters.AddWithValue("@IsActive", room.IsActive);
        command.Parameters.AddWithValue("@Status", room.Status);
        connection.Open();
        command.ExecuteNonQuery();
    }
}
