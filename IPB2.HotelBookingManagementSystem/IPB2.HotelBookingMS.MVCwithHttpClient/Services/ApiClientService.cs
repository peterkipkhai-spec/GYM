using System.Text.Json;

namespace IPB2.HotelBookingMS.MVCwithHttpClient.Services;

public class ApiClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Dictionary<string, object>>> GetListAsync(string endpoint)
    {
        var client = _httpClientFactory.CreateClient("HotelApi");
        var response = await client.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json) ?? new();
    }
}
