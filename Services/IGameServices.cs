namespace GameZone.Services
{
	public interface IGameServices
	{
		public Task Create(CreateGameFormViewModel CreateGameVM);
		public Game? GetGameById(int id);
		public IEnumerable<Game> GetAllGames();
		public Task<Game?> Update(EditGameFormViewModel EditGameVM);

		public bool Delete(int id);
	}
}
