namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class GenderRepository(DospinosdbContext context) : IGenderRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllGenderDTO>> GetAllAsync()
        {
            List<Gender> genderList = [.. await _context.Genders.ToListAsync()];
            return genderList.Select(GenderMapper.MapFrom).ToList();
        }
    }
}