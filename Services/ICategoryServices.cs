namespace GameZone.Services
{
	public interface ICategoryServices
	{
		public IEnumerable<SelectListItem> GetCategories();
	}
}
