namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DistrictRepository(DospinosdbContext context) : IDistrictRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllDistrictDTO>> GetAllAsync()
        {
            List<IGetAllDistrictDTO> response = [];

            List<District> districtList = [.. await _context.Districts.ToListAsync()];

            Parallel.ForEach(districtList, (district) =>
            {
                response.Add(DistrictMapper.MapFrom(district));
            });

            return response;
        }
    }
}