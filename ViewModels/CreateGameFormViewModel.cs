namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {
        [AllowedExtensions(Settings.FileSettings.AllowedExtensions)]
        [MaxFileSize(Settings.FileSettings.MaxFileSizeInB)]
        public IFormFile Cover { get; set; } = default!;

    }
}
