using System.ComponentModel.DataAnnotations;

namespace DosPinos.HRMS.Entities.ValidationAttributes
{
    internal class DateWihinLastCenturyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                DateTime hundredYearsAgo = DateTime.Today.AddYears(-100);

                if (date < hundredYearsAgo)
                {
                    return new ValidationResult("La fecha no puede ser anterior a hace 100 años.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
