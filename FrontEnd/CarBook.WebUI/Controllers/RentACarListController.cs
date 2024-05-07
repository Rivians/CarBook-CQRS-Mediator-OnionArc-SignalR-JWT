using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var bookPickDate = TempData["bookPickDate"];
            var bookOffDate = TempData["bookOffDate"];
            var timePick = TempData["timePick"];
            var timeOff = TempData["timeOff"];
            var locationID = TempData["locationID"];

            //filterRentACarDto.LocationID = int.Parse(locationID.ToString());
            //filterRentACarDto.Available = true;
            id = int.Parse(locationID.ToString());

            ViewBag.bookPickDate = bookPickDate;
            ViewBag.bookOffDate = bookOffDate;
            ViewBag.timePick = timePick;
            ViewBag.timeOff = timeOff;
            ViewBag.locationID = locationID;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7143/api/RentACars?locationId={id}&available=true");
            if(responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }                
            return View();
        }
    }
}
