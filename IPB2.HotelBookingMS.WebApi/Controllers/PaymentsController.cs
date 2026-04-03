using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly PaymentService _service;

    public PaymentsController(PaymentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());
}
