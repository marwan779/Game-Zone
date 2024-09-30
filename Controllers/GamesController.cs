
namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryServices _CategoryServices;
        private readonly IDeviceServices _DeviceServices;
        private readonly IGameServices _gameServices;

		public GamesController(ICategoryServices CategoryServices, IDeviceServices DeviceServices, IGameServices gameServices)
		{
			_CategoryServices = CategoryServices;
			_DeviceServices = DeviceServices;
			_gameServices = gameServices;
		}
        public IActionResult Index()
        {
            IEnumerable<Game> Games = _gameServices.GetAllGames();
            return View(Games);
        }

        public IActionResult Details(int id)
        {
            var Game = _gameServices.GetGameById(id);

            if(Game == null)
            {
                return NotFound();
            }

            return View(Game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel CreateGameVM = new()
			{
                Categories = _CategoryServices.GetCategories(),

				Devices = _DeviceServices.GetDevices()
			};


            return View(CreateGameVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel CreateGameVM)
        {
            if(!ModelState.IsValid)
            {
				CreateGameVM.Categories = _CategoryServices.GetCategories();
				CreateGameVM.Devices = _DeviceServices.GetDevices();

                return View(CreateGameVM);
			}

            await _gameServices.Create(CreateGameVM);

			return RedirectToAction(nameof(Index)); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
			var Game = _gameServices.GetGameById(id);

			if (Game == null)
			{
				return NotFound();
			}

            EditGameFormViewModel EditGameVM = new()
            {
                Id = id,
                Name = Game.Name,
                Description = Game.Description,
                CategoryId = Game.CategoryID,
                SelectedDevices = Game.Device.Select(d => d.DeviceId).ToList(),
                Categories = _CategoryServices.GetCategories(),
                Devices = _DeviceServices.GetDevices(),
                CurrentCover = Game.Cover,
            };

			return View(EditGameVM);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFormViewModel EditGameVM)
		{
			if (!ModelState.IsValid)
			{
				EditGameVM.Categories = _CategoryServices.GetCategories();
				EditGameVM.Devices = _DeviceServices.GetDevices();

				return View(EditGameVM);
			}

			Game? Result = await _gameServices.Update(EditGameVM);

            if (Result == null) return BadRequest();

			return RedirectToAction(nameof(Index));
		}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool IsDeleted = _gameServices.Delete(id);

            return IsDeleted? Ok() : BadRequest();
        }
	}
}
