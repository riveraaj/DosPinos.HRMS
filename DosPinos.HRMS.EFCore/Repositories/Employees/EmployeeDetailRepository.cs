using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details;
using DosPinos.HRMS.Entities.DTOs.Employees.Details;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class EmployeeDetailRepository(IInvokeStoredProcedure invokeSP) : IEmployeeDetailRepository
    {
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDetailDTO employeeDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", employeeDTO.EmployeeId},
                {"@dateBirth", employeeDTO.DateBirth},
                {"@children", employeeDTO.Children},
                {"@maritalStatus", employeeDTO.MaritalStatusId},
                {"@nationality", employeeDTO.NationalityId},
                {"@gender", employeeDTO.GenderId},
                {"@hiringType", employeeDTO.HiringTypeId},
                {"@jobTitle", employeeDTO.JobTitleId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateEmployeeDetail", parameters, false);
        }
    }
}