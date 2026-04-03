using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVC.Controllers;

public class RoomController : Controller
{
    private readonly RoomService _service;

    public RoomController(RoomService service)
    {
        _service = service;
    }

    public IActionResult Index() => View(_service.GetAll());
}
