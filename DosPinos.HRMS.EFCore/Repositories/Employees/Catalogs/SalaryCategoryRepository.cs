namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class SalaryCategoryRepository(DospinosdbContext context) : ISalaryCategoryRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllSalaryCategoryDTO> GetAll()
        {
            List<IGetAllSalaryCategoryDTO> response = [];

            List<SalaryCategory> salaryCategoryList = [.. _context.SalaryCategories];

            Parallel.ForEach(salaryCategoryList, (salaryCategory) =>
            {
                response.Add(SalaryCategoryMapper.MapFrom(salaryCategory));
            });

            return response;
        }
    }
}