namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class MaritalStatusRepository(DospinosdbContext context) : IMaritalStatusRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllMaritalStatusDTO>> GetAllAsync()
        {
            List<IGetAllMaritalStatusDTO> response = [];

            List<MaritalStatus> maritalStatusList = [.. await _context.MaritalStatuses.ToListAsync()];

            Parallel.ForEach(maritalStatusList, (maritalStatus) =>
            {
                response.Add(MaritalStatusMapper.MapFrom(maritalStatus));
            });

            return response;
        }
    }
}