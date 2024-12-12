namespace DosPinos.HRMS.EFCore.Mappers.Licenses.Catalogs
{
    internal static class IncapacityTypeMapper
    {
        public static IGetAllLicenseTypeDTO MapFrom(LicenseType licenseType)
           => new GetAllLicenseTypeDTO()
           {
               LicenseTypeId = licenseType.LicenseTypeId,
               LicenseTypeDescription = licenseType.LicenseTypeDescription,
           };
    }
}