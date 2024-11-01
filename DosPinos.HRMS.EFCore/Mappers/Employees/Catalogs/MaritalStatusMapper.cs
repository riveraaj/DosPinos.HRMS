namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class MaritalStatusMapper
    {
        public static IGetAllMaritalStatusDTO MapFrom(MaritalStatus maritalStatus)
           => new GetAllMaritalStatusDTO()
           {
               MaritalStatusId = maritalStatus.MaritalStatusId,
               MaritalStatusDescription = maritalStatus.MaritalStatusDescription,
           };
    }
}