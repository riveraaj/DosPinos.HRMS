namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class SalaryCategoryRepository(DospinosdbContext context) : ISalaryCategoryRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllSalaryCategoryDTO>> GetAllAsync()
        {
            List<IGetAllSalaryCategoryDTO> response = [];

            List<SalaryCategory> salaryCategoryList = [.. await _context.SalaryCategories.ToListAsync()];

            Parallel.ForEach(salaryCategoryList, (salaryCategory) =>
            {
                response.Add(SalaryCategoryMapper.MapFrom(salaryCategory));
            });

            return response;
        }
    }
}