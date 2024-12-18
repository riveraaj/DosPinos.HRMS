using DosPinos.HRMS.Entities.DTOs.Deductions;

namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DeductionRepository(DospinosdbContext context,
                                       IInvokeStoredProcedure invokeSP) : IDeductionRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreateDeductionDTO deductionDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@deductionDescription", deductionDTO.Description},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateDeduction", parameters, false);
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte deductionId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@deductionId", deductionId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_DeleteDeduction", parameters, false);
        }

        public async Task<IEnumerable<IGetAllDeductionDTO>> GetAllAsync()
        {
            List<Deduction> deductionList = [.. await _context.Deductions.ToListAsync()];
            return deductionList.Select(DeductionMapper.MapFrom).ToList();
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateDeductionDTO deductionDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@deductionId", deductionDTO.DeductionId},
                {"@deductionPercentage", deductionDTO.DeductionPercentage},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateDeduction", parameters, false);
        }
    }
}