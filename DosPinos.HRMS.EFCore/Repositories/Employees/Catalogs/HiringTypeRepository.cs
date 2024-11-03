namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class HiringTypeRepository(DospinosdbContext context) : IHiringTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllHiringTypeDTO>> GetAllAsync()
        {
            List<IGetAllHiringTypeDTO> response = [];

            List<HiringType> hiringTypeList = [.. await _context.HiringTypes.ToListAsync()];

            Parallel.ForEach(hiringTypeList, (hiringType) =>
            {
                response.Add(HiringTypeMapper.MapFrom(hiringType));
            });

            return response;
        }
    }
}