namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class DistrictMapper
    {

        public static IGetAllDistrictDTO MapFrom(District district)
           => new GetAllDistrictDTO()
           {
               CantonId = district.CantonId,
               DistrictId = district.DistrictId,
               DistrictDescription = district.DistrictDescription
           };
    }
}