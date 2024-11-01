namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class HiringTypeRepository(DospinosdbContext context) : IHiringTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllHiringTypeDTO> GetAll()
        {
            List<IGetAllHiringTypeDTO> response = [];

            List<HiringType> hiringTypeList = [.. _context.HiringTypes];

            Parallel.ForEach(hiringTypeList, (hiringType) =>
            {
                response.Add(HiringTypeMapper.MapFrom(hiringType));
            });

            return response;
        }
    }
}