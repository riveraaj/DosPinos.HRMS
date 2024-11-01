namespace DosPinos.HRMS.EFCore.Mappers.Overtimes.Catalogs
{
    internal static class OvertimeTypeMapper
    {
        public static IGetAllOvertimeTypeDTO MapFrom(OvertimeType overtimeType)
           => new GetAllOvertimeTypeDTO()
           {
               OvertimeTypeId = overtimeType.OvertimeTypeId,
               OvertimeTypeDescription = overtimeType.OvertimeTypeDescription,
               Multiplier = overtimeType.Multiplier
           };
    }
}