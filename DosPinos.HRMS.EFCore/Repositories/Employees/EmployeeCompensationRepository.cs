using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations;
using DosPinos.HRMS.Entities.DTOs.Employees.Compesations;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class EmployeeCompensationRepository(IInvokeStoredProcedure invokeSP) : IEmployeeCompensationRepository
    {
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeCompensationDTO employeeDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", employeeDTO.EmployeeId},
                {"@salaryCategory", employeeDTO.SalaryCategoryId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateEmployeeCompensation", parameters, false);
        }
    }
}