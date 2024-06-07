using CarBook.Application.Features.Mediator.Handlers.StatisticHandlers;
using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.StatisticRepositories;
using CarBook.WepApi.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.UnitTest
{
    public class LoginApiIntegrationTest
    {
		private TestServer _server;
		private HttpClient _client;

		[SetUp]
		public void Setup()
		{
			// TestServer oluşturuyoru<
			_server = new TestServer(new WebHostBuilder()  
			.UseEnvironment("Development")
				.UseStartup<Program>()); 

			_client = _server.CreateClient();
		}

		[TearDown]
		public void TearDown()
		{
			// olusturulan veri tabanı geçici oldugu için 
			//  hem client hem de serveri siliyoruz
			_client.Dispose();
			_server.Dispose();
		}

		[Test]
		public async Task Api_LoginTest()
		{
			// Arrange 
			var loginModel = new { Username = "Semih", Password = "1234" };
			var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

			// Action 
			var responseMessage = await _client.PostAsync("https://localhost:7143/api/Login", content);

			// Assert
			responseMessage.EnsureSuccessStatusCode(); // status kod geçersiz ise except return editoruz
			var responseString = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<dynamic>(responseString);
			Assert.NotNull(values.token); // values'in içinde token var mı yok mu kontrol ediyoruz
		}

	}
}
