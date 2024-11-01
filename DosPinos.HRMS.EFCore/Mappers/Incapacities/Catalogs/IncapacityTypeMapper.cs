namespace DosPinos.HRMS.EFCore.Mappers.Incapacities.Catalogs
{
    internal static class IncapacityTypeMapper
    {
        public static IGetAllIncapacityTypeDTO MapFrom(IncapacityType incapacityType)
           => new GetAllIncapacityTypeDTO()
           {
               IncapacityTypeId = incapacityType.IncapacityTypeId,
               IncapacityTypeDescription = incapacityType.IncapacityTypeDescription,
           };
    }
}