using System.ComponentModel.DataAnnotations;

namespace DosPinos.HRMS.Entities.ValidationAttributes
{
    internal class RequiredAndMaxLengthAttribute(int maxLength) : ValidationAttribute
    {
        private readonly int _maxLength = maxLength;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldName = validationContext.DisplayName;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult($"El campo {fieldName} es requerido y no puede estar vacío.");
            }

            if (value.ToString().Length > _maxLength)
            {
                return new ValidationResult($"El campo {fieldName} no puede tener más de {_maxLength} caracteres.");
            }

            return ValidationResult.Success;
        }
    }
}