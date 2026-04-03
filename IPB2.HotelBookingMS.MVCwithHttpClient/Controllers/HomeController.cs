using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVCwithHttpClient.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
