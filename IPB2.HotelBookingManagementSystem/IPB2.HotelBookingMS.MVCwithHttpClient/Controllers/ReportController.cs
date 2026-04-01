using IPB2.HotelBookingMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVCwithHttpClient.Controllers;

public class ReportController : Controller
{
    private readonly ApiClientService _api;

    public ReportController(ApiClientService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _api.GetListAsync("api/reports/booking");
        return View(data);
    }
}
