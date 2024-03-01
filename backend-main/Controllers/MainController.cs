using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using backend_main.Models;
using Newtonsoft.Json;
using backend_main.Models.Responses;
using backend_main.Interfaces;

namespace backend_main.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MainController : ControllerBase
	{
		private readonly ILogger<MainController> _logger;

		private HttpClient _httpClient;
		private readonly string _baseUrl = "https://localhost:444";
		private readonly IArticleService _articleService;

		public MainController(ILogger<MainController> logger, IArticleService articleService)
		{
			_logger = logger;

			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

			_httpClient = new HttpClient(httpClientHandler);

			_articleService = articleService;
		}

		[HttpGet]
		[Route("GetArticles")]
		public List<ArticleResponse> GetArticles()
		{
			List<Article> result = _articleService.GetArticles();

			return result
					.Select(x => new ArticleResponse(x.Id, x.Name, x.Description, x.Price))
					.ToList();
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