namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class ProvinceRepository(DospinosdbContext context) : IProvinceRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllProvinceDTO>> GetAllAsync()
        {
            List<Province> provinceList = [.. await _context.Provinces.ToListAsync()];
            return provinceList.Select(ProvinceMapper.MapFrom).ToList();
        }
    }
}