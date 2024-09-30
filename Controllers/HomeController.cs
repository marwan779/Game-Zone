using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
	public class HomeController : Controller
	{
		private readonly IGameServices _gameService;

		public HomeController(IGameServices GameService)
		{
			_gameService = GameService;
		}

		public IActionResult Index()
		{
			IEnumerable<Game> Games = _gameService.GetAllGames();
			return View(Games);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
