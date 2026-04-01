using IPB2.HotelBookingMS.Domain;
using Microsoft.Data.SqlClient;

namespace IPB2.HotelBookingMS.Database;

public class ReportService
{
    private readonly AdoDotNetService _adoService;

    public ReportService(AdoDotNetService adoService)
    {
        _adoService = adoService;
    }

    public List<Dictionary<string, object>> GetReport(string viewName)
    {
        var result = new List<Dictionary<string, object>>();
        using var connection = _adoService.CreateConnection();
        using var command = new SqlCommand($"SELECT * FROM {viewName}", connection);
        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var row = new Dictionary<string, object>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                row[reader.GetName(i)] = reader.GetValue(i);
            }
            result.Add(row);
        }

        return result;
    }
}
