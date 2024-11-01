namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class SalaryCategoryMapper
    {
        public static IGetAllSalaryCategoryDTO MapFrom(SalaryCategory salaryCategory)
           => new GetAllSalaryCategoryDTO()
           {
               SalaryCategoryId = salaryCategory.SalaryCategoryId,
               SalaryCategoryDescription = salaryCategory.SalaryCategoryDescription,
               SalaryCategoryRange = salaryCategory.SalaryCategoryRange,
           };
    }
}