using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly ReportService _service;

    public ReportsController(ReportService service)
    {
        _service = service;
    }

    [HttpGet("booking")]
    public IActionResult BookingReport() => Ok(_service.GetReport("vw_BookingReport"));

    [HttpGet("room-availability")]
    public IActionResult RoomAvailability() => Ok(_service.GetReport("vw_RoomAvailabilityReport"));

    [HttpGet("customer-stay-summary")]
    public IActionResult CustomerStaySummary() => Ok(_service.GetReport("vw_CustomerStaySummary"));
}
