namespace DosPinos.HRMS.BusinessObjects.ValidationAttributes
{
    internal class RequiredAndMaxLengthAttribute(int maxLength) : ValidationAttribute
    {
        private readonly int _maxLength = maxLength;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("El campo es requerido y no puede estar vacío.");
            }

            if (value.ToString().Length > _maxLength)
            {
                return new ValidationResult($"El campo no puede tener más de {_maxLength} caracteres.");
            }

            return ValidationResult.Success;
        }
    }
}