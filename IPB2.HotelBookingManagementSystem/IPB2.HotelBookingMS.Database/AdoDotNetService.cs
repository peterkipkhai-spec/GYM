using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace IPB2.HotelBookingMS.Database;

public class AdoDotNetService
{
    private readonly string _connectionString;

    public AdoDotNetService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public SqlConnection CreateConnection() => new(_connectionString);
}
