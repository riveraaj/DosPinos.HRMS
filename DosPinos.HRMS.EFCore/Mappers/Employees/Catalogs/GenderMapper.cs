namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class GenderMapper
    {
        public static IGetAllGenderDTO MapFrom(Gender gender)
           => new GetAllGenderDTO()
           {
               GenderId = gender.GenderId,
               GenderDescription = gender.GenderDescription,
           };
    }
}
