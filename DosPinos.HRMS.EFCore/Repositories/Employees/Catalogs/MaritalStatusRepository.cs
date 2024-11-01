namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class MaritalStatusRepository(DospinosdbContext context) : IMaritalStatusRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllMaritalStatusDTO> GetAll()
        {
            List<IGetAllMaritalStatusDTO> response = [];

            List<MaritalStatus> maritalStatusList = [.. _context.MaritalStatuses];

            Parallel.ForEach(maritalStatusList, (maritalStatus) =>
            {
                response.Add(MaritalStatusMapper.MapFrom(maritalStatus));
            });

            return response;
        }
    }
}