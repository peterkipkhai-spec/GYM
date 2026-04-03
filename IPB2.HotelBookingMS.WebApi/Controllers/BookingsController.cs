using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingService _service;

    public BookingsController(BookingService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());
}
