using DosPinos.HRMS.Entities.DTOs.SalaryCategories;

namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class SalaryCategoryRepository(DospinosdbContext context,
                                            IInvokeStoredProcedure invokeSP) : ISalaryCategoryRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreateSalaryCategoryDTO salaryCategoryDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@salaryCategoryDescription", salaryCategoryDTO},
                {"@salaryCategoryRange", salaryCategoryDTO},
                {"@incomeTaxId", salaryCategoryDTO},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateSalaryCategory", parameters, false);
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte salaryCategoryId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@salaryCategoryId", salaryCategoryId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_DeleteSalaryCategory", parameters, false);
        }

        public async Task<IEnumerable<IGetAllSalaryCategoryDTO>> GetAllAsync()
        {
            List<SalaryCategory> salaryCategoryList = [.. await _context.SalaryCategories.ToListAsync()];
            return salaryCategoryList.Select(SalaryCategoryMapper.MapFrom).ToList();
        }
    }
}