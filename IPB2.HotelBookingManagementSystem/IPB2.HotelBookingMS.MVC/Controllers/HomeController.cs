using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
