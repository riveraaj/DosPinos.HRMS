namespace DosPinos.HRMS.EFCore.Mappers.Incapacities.Catalogs
{
    internal static class IncapacityTypeMapper
    {
        public static IGetAllIncapacityTypeDTO MapFrom(SpecialPermissionType specialPermissionType)
           => new GetAllIncapacityTypeDTO()
           {
               IncapacityTypeId = specialPermissionType.SpecialPermissionTypeId,
               IncapacityTypeDescription = specialPermissionType.SpecialPermissionTypeDescription,
           };
    }
}