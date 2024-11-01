namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class HiringTypeMapper
    {
        public static IGetAllHiringTypeDTO MapFrom(HiringType hiringType)
           => new GetAllHiringTypeDTO()
           {
               HiringTypeId = hiringType.HiringTypeId,
               HiringTypeDescription = hiringType.HiringTypeDescription,
           };
    }
}