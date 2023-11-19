using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using backend_main.Models;
using Newtonsoft.Json;
using backend_main.Models.Responses;

namespace backend_main.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MainController : ControllerBase
	{
		private readonly ILogger<MainController> _logger;

		private HttpClient _httpClient;
		private readonly string _baseUrl = "https://localhost:444";

		public MainController(ILogger<MainController> logger)
		{
			_logger = logger;

			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

			_httpClient = new HttpClient(httpClientHandler);
		}

		[HttpPost]
		[Route("GetData")]
		async public Task<string> GetData(User data)
		{
			var request = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Auth/Authenticate", data).WaitAsync(CancellationToken.None);
			var response = request.Content.ReadFromJsonAsync<UserResponse>();

			UserResponse? result = response.Result;
			result = response.Result;

			return JsonConvert.SerializeObject(result);
		}
	}
}