using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7143/api/Abouts");

            if (responseMessage.IsSuccessStatusCode)
            {
                // HTTP cevabının içeriğini asenkron bir şekilde okur ve sonucunu Task<string> olarak döndürür. Bu görevin sonucu, cevabın içeriğidir ve bir dize olarak temsil edilir.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // Bu satırın genel amacı, HTTP cevabının içeriğini temsil eden jsonData string'ini, ResultAboutDto türündeki nesnelerin bir listesine dönüştürmektir. 
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData); 
                return View(values);
            }
            return View();            
        }
    }
}
