namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class NationalityMapper
    {
        public static IGetAllNationalityDTO MapFrom(Nationality nationality)
           => new GetAllNationalityDTO()
           {
               NationalityId = nationality.NationalityId,
               NationalityDescription = nationality.NationalityDescription,
           };
    }
}