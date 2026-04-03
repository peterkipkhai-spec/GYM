using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVC.Controllers;

public class StaffController : Controller
{
    private readonly StaffService _service;

    public StaffController(StaffService service)
    {
        _service = service;
    }

    public IActionResult Index() => View(_service.GetAll());
}
