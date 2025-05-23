﻿using System.Text.RegularExpressions;

namespace DosPinos.HRMS.BusinessObjects.ValidationAttributes
{
    internal class IdentificationCostaRicaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.Equals("0"))
            {
                return new ValidationResult("La cédula es obligatoria.");
            }

            string cedula = value.ToString();

            if (!Regex.IsMatch(cedula, @"^\d{9}$"))
            {
                return new ValidationResult("La cédula debe tener 9 dígitos.");
            }

            return ValidationResult.Success;
        }
    }
}