namespace GameZone.Services
{
	public class GameServices : IGameServices
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _imagePath;
		public GameServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			_imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
		}
		public async Task Create(CreateGameFormViewModel CreateGameVM)
		{
			var CoverName = await SaveCover(CreateGameVM.Cover);

			Game game = new()
			{
				Name = CreateGameVM.Name,
				Description = CreateGameVM.Description,
				CategoryID = CreateGameVM.CategoryId,
				Cover = CoverName,
				Device = CreateGameVM.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
			};

			_context.Games.Add(game);
			await _context.SaveChangesAsync();
		}

		

		public IEnumerable<Game> GetAllGames()
		{
			return _context.Games
				.Include(g => g.Category)
				.Include(g => g.Device)
				.ThenInclude(g => g.Device)
				.AsNoTracking()
				.ToList();
		}

        public Game? GetGameById(int id)
        {
            return _context.Games
                .Include(g => g.Category)
                .Include(g => g.Device)
                .ThenInclude(g => g.Device)
                .AsNoTracking()
                .SingleOrDefault(g => g.Id == id);
        }

		public async Task<Game?> Update(EditGameFormViewModel EditGameVM)
		{
			Game? Game = _context.Games
				.Include(g => g.Device)
				.SingleOrDefault(g => g.Id == EditGameVM.Id);

			if (Game == null) return null;

			Game.Name = EditGameVM.Name;
			Game.Description = EditGameVM.Description;
			Game.CategoryID = EditGameVM.CategoryId;
			Game.Device = EditGameVM.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

			bool HasNewCover = EditGameVM.Cover == null? false: true;
			string OldCover = Game.Cover;

			if(HasNewCover)
			{
				Game.Cover = await SaveCover(EditGameVM.Cover!);
			}

			int AffectedRows = _context.SaveChanges();

			if(AffectedRows > 0)
			{
				if(HasNewCover)
				{
					string OldCoverPath = Path.Combine(_imagePath, OldCover);
					File.Delete(OldCoverPath);
				}

				return Game;
			}
			else
			{
				string NewCoverPath = Path.Combine(_imagePath, Game.Cover);
				File.Delete(NewCoverPath);
				return null;
			}

		}

		public bool Delete(int id)
		{
			bool IsDeleted = false;

			Game? Game = _context.Games.Find(id);

			if(Game == null) return IsDeleted;

			_context.Games.Remove(Game);

			int AffectedRows = _context.SaveChanges();

			if(AffectedRows > 0) 
			{
				IsDeleted = true;
				string ImagePath = Path.Combine(_imagePath, Game.Cover);
				File.Delete(ImagePath);	
			}


			return IsDeleted;
		}

		private async Task<string> SaveCover(IFormFile Cover)
		{
			var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
			var path = Path.Combine(_imagePath, CoverName);

			using var Stream = File.Create(path);
			await Cover.CopyToAsync(Stream);

			return CoverName;
		}
	}
}
