using System.ComponentModel.DataAnnotations;

namespace DosPinos.HRMS.Entities.ValidationAttributes
{
    internal class ValidarPhoneNumberAttribute : ValidationAttribute
    {
        public ValidarPhoneNumberAttribute()
        {
            ErrorMessage = "El número celular debe tener exactamente 8 dígitos.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int numeroCelular)
            {
                string numeroCelularStr = numeroCelular.ToString();

                if (numeroCelularStr.Length != 8)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            else
            {
                return new ValidationResult("El valor proporcionado no es un número de celular válido.");
            }

            return ValidationResult.Success;
        }
    }
}