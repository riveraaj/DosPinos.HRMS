namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DistrictRepository(DospinosdbContext context) : IDistrictRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllDistrictDTO>> GetAllAsync()
        {
            List<District> districtList = [.. await _context.Districts.ToListAsync()];
            return districtList.Select(DistrictMapper.MapFrom).ToList();
        }
    }
}