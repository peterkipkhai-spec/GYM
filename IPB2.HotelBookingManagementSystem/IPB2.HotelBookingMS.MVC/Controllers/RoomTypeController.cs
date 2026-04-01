using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVC.Controllers;

public class RoomTypeController : Controller
{
    private readonly RoomTypeService _service;

    public RoomTypeController(RoomTypeService service)
    {
        _service = service;
    }

    public IActionResult Index() => View(_service.GetAll());
}
