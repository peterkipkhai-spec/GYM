using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly StaffService _service;

    public StaffController(StaffService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());
}
