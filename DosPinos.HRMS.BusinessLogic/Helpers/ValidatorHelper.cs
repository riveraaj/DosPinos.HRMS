namespace DosPinos.HRMS.BusinessLogic.Helpers
{
    internal static class ValidatorHelper
    {
        internal static ValidationResult ValidateModel(this object model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            return new ValidationResult
            {
                IsValid = isValid,
                ErrorMessages = validationResults.Select(r => r.ErrorMessage).ToList()
            };
        }
    }

    internal class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessages { get; set; } = [];
    }
}