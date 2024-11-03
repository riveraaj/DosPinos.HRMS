namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class ProvinceRepository(DospinosdbContext context) : IProvinceRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllProvinceDTO>> GetAllAsync()
        {
            List<IGetAllProvinceDTO> response = [];

            List<Province> provinceList = [.. await _context.Provinces.ToListAsync()];

            Parallel.ForEach(provinceList, (province) =>
            {
                response.Add(ProvinceMapper.MapFrom(province));
            });

            return response;
        }
    }
}