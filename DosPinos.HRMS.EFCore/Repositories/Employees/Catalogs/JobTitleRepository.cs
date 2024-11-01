namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class JobTitleRepository(DospinosdbContext context) : IJobTitleRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllJobTitleDTO> GetAll()
        {
            List<IGetAllJobTitleDTO> response = [];

            List<JobTitle> jobTitleList = [.. _context.JobTitles];

            Parallel.ForEach(jobTitleList, (jobTitle) =>
            {
                response.Add(JobTitleMapper.MapFrom(jobTitle));
            });

            return response;
        }
    }
}