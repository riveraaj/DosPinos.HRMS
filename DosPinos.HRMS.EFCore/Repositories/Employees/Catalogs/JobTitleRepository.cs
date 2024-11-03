namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class JobTitleRepository(DospinosdbContext context) : IJobTitleRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllJobTitleDTO>> GetAllAsync()
        {
            List<IGetAllJobTitleDTO> response = [];

            List<JobTitle> jobTitleList = [.. await _context.JobTitles.ToListAsync()];

            Parallel.ForEach(jobTitleList, (jobTitle) =>
            {
                response.Add(JobTitleMapper.MapFrom(jobTitle));
            });

            return response;
        }
    }
}