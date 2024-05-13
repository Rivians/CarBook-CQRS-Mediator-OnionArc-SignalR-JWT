using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region istatistik 1 
            var responseMessage1 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                string jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.carCount = values1.CarCount;
            }
            #endregion

            #region istatistik 2 
            var responseMessage2 = await client.GetAsync("https://localhost:7143/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                string jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
            }
            #endregion

            #region istatistik 3 
            var responseMessage3 = await client.GetAsync("https://localhost:7143/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                string jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.brandCount = values3.BrandCount;
            }
            #endregion

            #region istatistik 4 
            var responseMessage4 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage4.IsSuccessStatusCode)
            {
                string jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.electricCarCount = values4.CarCountByFuelElectric;
            }
            #endregion            

            return View();
        }
    }
}
