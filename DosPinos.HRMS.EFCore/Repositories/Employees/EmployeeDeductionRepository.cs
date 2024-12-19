using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions;
using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class EmployeeDeductionRepository(DospinosdbContext context,
                                      IInvokeStoredProcedure invokeSP) : IEmployeeDeductionRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(UpdateEmployeeDeductionDTO deductionDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", deductionDTO.EmployeeId},
                {"@deductionId", deductionDTO.DeductionId},
                {"@percentageDeduction", deductionDTO.DeductionPercentage},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateEmployeeDeduction", parameters, false);
        }

        public async Task<IOperationResponseVO> DeleteAsync(int deductionId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeDeductionId", deductionId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_DeleteEmployeeDeduction", parameters, false);
        }

        public async Task<IEnumerable<GetAllEmployeeDeductionDTO>> GetAllAsync(int employeeId)
        {
            List<EmployeeDeduction> deductions = await _context.EmployeeDeductions.Include(x => x.Deduction)
                                                                                  .Where(x => x.EmployeeId == employeeId && (x.EmployeeDeductionId != 1) && (x.EmployeeDeductionId != 2) && (x.EmployeeDeductionId != 3))
                                                                                  .ToListAsync();
            return deductions.Select(x => new GetAllEmployeeDeductionDTO
            {
                EmployeeDeductionId = x.EmployeeDeductionId,
                DeductionDescription = x.Deduction.DeductionDescription,
                Percentage = x.DeductionPercentage,
            }).ToList();
        }
    }
}