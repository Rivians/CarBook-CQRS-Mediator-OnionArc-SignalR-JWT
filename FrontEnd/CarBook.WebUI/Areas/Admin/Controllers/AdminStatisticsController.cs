using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminStatistics")]
	public class AdminStatisticsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.carCount = GetApiResult<ResultCarCountDto>("GetCarCount").Result.CarCount;
            ViewBag.locationCount = GetApiResult<ResultLocationCountDto>("GetLocationCount").Result.LocationCount;
            ViewBag.authorCount = GetApiResult<ResultAuthorCountDto>("GetAuthorCount").Result.AuthorCount;
            ViewBag.blogCount = GetApiResult<ResultBlogCountDto>("GetBlogCount").Result.BlogCount;
            ViewBag.brandCount = GetApiResult<ResultBrandCountDto>("GetBrandCount").Result.BrandCount;
            ViewBag.avgDailyPrice = GetApiResult<AvgRentPriceForDailyDto>("GetAvgRentPriceForDaily").Result.AvgRentPriceForDaily;
            ViewBag.avgWeeklyPrice = GetApiResult<AvgRentPriceForWeeklyDto>("GetAvgRentPriceForWeekly").Result.AvgRentPriceForWeekly;
            ViewBag.avgMonthlyPrice = GetApiResult<AvgRentPriceForMonthlyDto>("GetAvgRentPriceForMonthly").Result.AvgRentPriceForMonthly;
            ViewBag.autoCarCount = GetApiResult<ResultCarCountTransmissionIsAutoDto>("GetCarCountByTransmissionIsAuto").Result.CarCountByTransmissionIsAuto;
          ViewBag.brandNameByMaxCar = GetApiResult<ResultBrandNameByMaxCarDto>("GetBrandNameByMaxCar").Result.BrandNameByMaxCar;
        //  ViewBag.blogTitleByMaxBlogComment = GetApiResult<ResultBlogTitleByMaxBlogCommentDto>("GetBlogTitleByMaxBlogComment").Result.BlogTitleByMaxBlogComment;
            ViewBag.carCountSmallerThan1000 = GetApiResult<ResultCarCountByKmSmallerThan1000Dto>("GetCarCountByKmSmallerThan1000").Result.CarCountByKmSmallerThan1000;
            ViewBag.carByGasolineOrDiesel = GetApiResult<ResultCarCountByFuelGasolineOrDieselDto>("GetCarCountByFuelGasolineOrDiesel").Result.CarCountByFuelGasolineOrDiesel;
            ViewBag.carElectricCount = GetApiResult<ResultCarCountByFuelElectricDto>("GetCarCountByFuelElectric").Result.CarCountByFuelElectric;
            ViewBag.carRentPriceMaxBrandAndModel = GetApiResult<ResultCarBrandAndModelByRentPriceDailyMaxDto>("GetCarBrandAndModelByRentPriceDailyMax").Result.CarBrandAndModelByRentPriceDailyMax;
            ViewBag.carRentPriceMinBrandAndModel = GetApiResult<ResultCarBrandAndModelByRentPriceDailyMinDto>("GetCarBrandAndModelByRentPriceDailyMin").Result.CarBrandAndModelByRentPriceDailyMin;
            return View();
        }

        public async Task<T> GetApiResult<T>(string methodApiUrl)
        {
            string newApiUrl = "https://localhost:7143/api/Statistics/";
            newApiUrl += methodApiUrl;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(newApiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return values;
            }
            return default;
        }
    }
}
