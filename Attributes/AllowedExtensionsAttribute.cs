namespace GameZone.Attributes
{
	public class AllowedExtensionsAttribute : ValidationAttribute
	{
		private readonly string _allowedExtensions;

        public AllowedExtensionsAttribute(string AllowedExtensions)
        {
            _allowedExtensions = AllowedExtensions;
        }

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var File = value as IFormFile;

			if (File != null)
			{
				var Extensions = Path.GetExtension(File.FileName);

				bool IsAllowed = _allowedExtensions.Split(',').Contains(Extensions, StringComparer.OrdinalIgnoreCase);

				if (!IsAllowed)
				{
					return new ValidationResult($"Only {_allowedExtensions} is allowed!");
				}
			}
			return ValidationResult.Success;

		}
	}
}
