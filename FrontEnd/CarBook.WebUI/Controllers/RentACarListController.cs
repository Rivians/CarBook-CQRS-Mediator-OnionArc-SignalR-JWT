using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            var bookPickDate = TempData["bookPickDate"];
            var bookOffDate = TempData["bookOffDate"];
            var timePick = TempData["timePick"];
            var timeOff = TempData["timeOff"];
            var locationID = TempData["locationID"];

            ViewBag.bookPickDate = bookPickDate;
            ViewBag.bookOffDate = bookOffDate;
            ViewBag.timePick = timePick;
            ViewBag.timeOff = timeOff;
            ViewBag.locationID = locationID;

            return View();
        }
    }
}
