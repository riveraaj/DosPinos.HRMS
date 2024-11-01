namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class NationalityRepository(DospinosdbContext context) : INationalityRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllNationalityDTO> GetAll()
        {
            List<IGetAllNationalityDTO> response = [];

            List<Nationality> nationalityList = [.. _context.Nationalities];

            Parallel.ForEach(nationalityList, (nationality) =>
            {
                response.Add(NationalityMapper.MapFrom(nationality));
            });

            return response;
        }
    }
}