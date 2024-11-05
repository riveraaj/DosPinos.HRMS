namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class JobTitleRepository(DospinosdbContext context) : IJobTitleRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllJobTitleDTO>> GetAllAsync()
        {
            List<JobTitle> jobTitleList = [.. await _context.JobTitles.ToListAsync()];
            return jobTitleList.Select(JobTitleMapper.MapFrom).ToList();
        }
    }
}