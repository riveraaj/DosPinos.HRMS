namespace DosPinos.HRMS.EFCore.Mappers.Incapacities.Catalogs
{
    internal static class IncapacityTypeMapper
    {
        public static IGetAllIncapacityTypeDTO MapFrom(LicenseType licenseType)
           => new GetAllIncapacityTypeDTO()
           {
               IncapacityTypeId = licenseType.LicenseTypeId,
               IncapacityTypeDescription = licenseType.LicenseTypeDescription,
           };
    }
}