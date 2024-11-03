namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class NationalityRepository(DospinosdbContext context) : INationalityRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllNationalityDTO>> GetAllAsync()
        {
            List<IGetAllNationalityDTO> response = [];

            List<Nationality> nationalityList = [.. await _context.Nationalities.ToListAsync()];

            Parallel.ForEach(nationalityList, (nationality) =>
            {
                response.Add(NationalityMapper.MapFrom(nationality));
            });

            return response;
        }
    }
}