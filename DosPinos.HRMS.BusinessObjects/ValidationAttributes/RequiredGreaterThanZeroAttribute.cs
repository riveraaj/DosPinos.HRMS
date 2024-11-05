namespace DosPinos.HRMS.BusinessObjects.ValidationAttributes
{
    internal class RequiredGreaterThanZeroAttribute : ValidationAttribute
    {
        public RequiredGreaterThanZeroAttribute()
        {
            ErrorMessageResourceName = "FieldRequired";
            ErrorMessageResourceType = typeof(Resources.Commons.Commons);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (value)
            {
                case sbyte sb when sb <= 0:
                case byte b when b <= 0:
                case short s when s <= 0:
                case ushort us when us <= 0:
                case int i when i <= 0:
                case uint ui when ui <= 0:
                case long l when l <= 0:
                case ulong ul when ul <= 0:
                case float f when f <= 0:
                case double d when d <= 0:
                case decimal dec when dec <= 0:
                    string errorMessage = string.Format(ErrorMessageString, validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                case sbyte or byte or short or ushort or int or uint or long or ulong or float or double or decimal:
                    return ValidationResult.Success;
                default:
                    return new ValidationResult("El tipo de dato no es válido para esta validación.");
            }
        }
    }
}