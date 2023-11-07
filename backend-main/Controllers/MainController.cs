using backend_main.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace backend_main.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MainController : ControllerBase
	{
		private readonly ILogger<MainController> _logger;
		private HttpClient _httpClient;
		private readonly string _baseUrl = "https://172.10.0.20:443";

		public MainController(ILogger<MainController> logger)
		{
			_logger = logger;

			var httpClientHandler = new HttpClientHandler();
			// Return `true` to allow certificates that are untrusted/invalid
			httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

			_httpClient = new HttpClient(httpClientHandler);
		}

		[HttpPost]
		[Route("GetData")]
		async public Task<string> GetData(User data)
		{
			var request = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Auth/Authenticate", data).WaitAsync(CancellationToken.None);
			string? response = request.Content.ToString();

			// Create requests and response classes. Remove them from auth backend?

			string? result;
			if (response == null)
				result = "Je bent niet ingelogd!";
			else
				result = JsonConvert.SerializeObject(new User());

			return result;
		}
	};
}