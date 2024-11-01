namespace DosPinos.HRMS.BusinessObjects.ValidationAttributes
{
    internal class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue >= DateTime.Now;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} debe ser una fecha futura.";
        }
    }
}