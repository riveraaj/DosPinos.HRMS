namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class DeductionMapper
    {
        public static IGetAllDeductionDTO MapFrom(Deduction deduction)
            => new GetAllDeductionDTO()
            {
                DeductionId = deduction.DeductionId,
                DeductionDescription = deduction.DeductionDescription,
                DeductionPercentage = deduction.DeductionPercentage,
            };
    }
}