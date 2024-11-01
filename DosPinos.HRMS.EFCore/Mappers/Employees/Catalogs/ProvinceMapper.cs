namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class ProvinceMapper
    {
        public static IGetAllProvinceDTO MapFrom(Province province)
           => new GetAllProvinceDTO()
           {
               ProvinceId = province.ProvinceId,
               ProvinceDescription = province.ProvinceDescription,
           };
    }
}