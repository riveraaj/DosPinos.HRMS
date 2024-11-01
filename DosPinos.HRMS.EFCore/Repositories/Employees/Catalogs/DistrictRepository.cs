namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DistrictRepository(DospinosdbContext context) : IDistrictRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllDistrictDTO> GetAll()
        {
            List<IGetAllDistrictDTO> response = [];

            List<District> districtList = [.. _context.Districts];

            Parallel.ForEach(districtList, (district) =>
            {
                response.Add(DistrictMapper.MapFrom(district));
            });

            return response;
        }
    }
}