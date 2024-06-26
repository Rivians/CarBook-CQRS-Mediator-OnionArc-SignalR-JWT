﻿using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if(token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7143/api/Locations");

                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> dropdownItems = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.LocationId.ToString()
                                                      }).ToList();
                ViewBag.v = dropdownItems;
            }
            return View();            
        }

        [HttpPost]
        public async Task<IActionResult> Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationID)
        {
            TempData["bookPickDate"] = book_pick_date;
            TempData["bookOffDate"] = book_off_date;
            TempData["timePick"] = time_pick;
            TempData["timeOff"] = time_off;
            TempData["locationID"] = locationID;
            return RedirectToAction("Index","RentACarList");
        }
    }
}
