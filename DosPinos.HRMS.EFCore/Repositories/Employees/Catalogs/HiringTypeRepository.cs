namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class HiringTypeRepository(DospinosdbContext context) : IHiringTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllHiringTypeDTO>> GetAllAsync()
        {
            List<HiringType> hiringTypeList = [.. await _context.HiringTypes.ToListAsync()];
            return hiringTypeList.Select(HiringTypeMapper.MapFrom).ToList();
        }
    }
}