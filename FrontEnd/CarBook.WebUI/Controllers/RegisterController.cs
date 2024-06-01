using CarBook.Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult CreateAppUser()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
		{
			var jsonData = JsonConvert.SerializeObject(createRegisterDto);
			var client = _httpClientFactory.CreateClient();
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7143/api/Registers", stringContent);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
