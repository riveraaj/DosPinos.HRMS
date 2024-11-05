namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class SalaryCategoryRepository(DospinosdbContext context) : ISalaryCategoryRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllSalaryCategoryDTO>> GetAllAsync()
        {
            List<SalaryCategory> salaryCategoryList = [.. await _context.SalaryCategories.ToListAsync()];
            return salaryCategoryList.Select(SalaryCategoryMapper.MapFrom).ToList();
        }
    }
}