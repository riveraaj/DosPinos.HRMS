namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class CantonMapper
    {
        public static IGetAllCantonDTO MapFrom(Canton canton)
            => new GetAllCantonDTO()
            {
                CantonId = canton.CantonId,
                CantonDescription = canton.CantonDescription,
                ProvinceId = canton.ProvinceId
            };
    }
}