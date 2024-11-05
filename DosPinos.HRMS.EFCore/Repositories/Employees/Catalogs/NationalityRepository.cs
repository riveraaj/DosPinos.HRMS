namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class NationalityRepository(DospinosdbContext context) : INationalityRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllNationalityDTO>> GetAllAsync()
        {
            List<Nationality> nationalityList = [.. await _context.Nationalities.ToListAsync()];
            return nationalityList.Select(NationalityMapper.MapFrom).ToList();
        }
    }
}