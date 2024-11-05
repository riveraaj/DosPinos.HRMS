namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class MaritalStatusRepository(DospinosdbContext context) : IMaritalStatusRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllMaritalStatusDTO>> GetAllAsync()
        {
            List<MaritalStatus> maritalStatusList = [.. await _context.MaritalStatuses.ToListAsync()];
            return maritalStatusList.Select(MaritalStatusMapper.MapFrom).ToList();
        }
    }
}