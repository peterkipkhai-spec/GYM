using IPB2.HotelBookingMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVCwithHttpClient.Controllers;

public class CustomerController : Controller
{
    private readonly ApiClientService _api;

    public CustomerController(ApiClientService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _api.GetListAsync("api/customers");
        return View(data);
    }
}
