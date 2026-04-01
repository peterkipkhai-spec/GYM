using IPB2.HotelBookingMS.Database;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.HotelBookingMS.MVC.Controllers;

public class ReportController : Controller
{
    private readonly ReportService _service;

    public ReportController(ReportService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        ViewBag.BookingReport = _service.GetReport("vw_BookingReport");
        ViewBag.RoomAvailability = _service.GetReport("vw_RoomAvailabilityReport");
        ViewBag.CustomerStay = _service.GetReport("vw_CustomerStaySummary");
        return View();
    }
}
