using Microsoft.AspNetCore.Mvc;

namespace backend_main.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MainController : ControllerBase
	{
		private readonly ILogger<MainController> _logger;
		private readonly string m_Username = "Gekke henkie";

		public MainController(ILogger<MainController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("GetUsername")]
		public string GetUsername()
		{
			return m_Username;
		}
	};
}