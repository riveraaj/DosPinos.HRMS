namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class CantonRepository(DospinosdbContext context) : ICantonRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllCantonDTO>> GetAllAsync()
        {
            List<Canton> cantonList = [.. await _context.Cantons.ToListAsync()];
            return cantonList.Select(CantonMapper.MapFrom).ToList();
        }
    }
}