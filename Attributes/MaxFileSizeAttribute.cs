namespace GameZone.Attributes
{
	public class MaxFileSizeAttribute : ValidationAttribute
	{
		private readonly int _maxFileSize;
		public MaxFileSizeAttribute(int MaxFileSize) 
		{
			_maxFileSize = MaxFileSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var File = value as IFormFile;

			if (File != null)
			{
				if(File.Length > _maxFileSize)
				{
					return new ValidationResult($"The maximum allowed size is {_maxFileSize} byte");
				}
			}

			return ValidationResult.Success;
		}
	}
}
