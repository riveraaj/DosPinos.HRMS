namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class JobTitleMapper
    {
        public static IGetAllJobTitleDTO MapFrom(JobTitle jobTitle)
           => new GetAllJobTitleDTO()
           {
               JobTitleId = jobTitle.JobTitleId,
               JobTitleDescription = jobTitle.JobTitleDescription,
           };
    }
}