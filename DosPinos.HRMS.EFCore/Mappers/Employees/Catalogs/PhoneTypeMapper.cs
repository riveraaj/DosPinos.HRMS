namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class PhoneTypeMapper
    {
        public static IGetAllPhoneTypeDTO MapFrom(PhoneType phoneType)
           => new GetAllPhoneTypeDTO()
           {
               PhoneTypeId = phoneType.PhoneTypeId,
               PhoneTypeDescription = phoneType.PhoneTypeDescription,
           };
    }
}