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
            if (value is int intValue)
            {
                if (intValue <= 0) return new ValidationResult(ErrorMessage);
            }
            else return new ValidationResult("El tipo de dato no es válido para esta validación.");

            return ValidationResult.Success;
        }
    }
}
