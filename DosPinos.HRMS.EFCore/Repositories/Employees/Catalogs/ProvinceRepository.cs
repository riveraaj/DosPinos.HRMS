namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class ProvinceRepository(DospinosdbContext context) : IProvinceRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllProvinceDTO> GetAll()
        {
            List<IGetAllProvinceDTO> response = [];

            List<Province> provinceList = [.. _context.Provinces];

            Parallel.ForEach(provinceList, (province) =>
            {
                response.Add(ProvinceMapper.MapFrom(province));
            });

            return response;
        }
    }
}