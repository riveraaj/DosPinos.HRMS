using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones;
using DosPinos.HRMS.Entities.DTOs.Employees.Phones;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class PhoneRepository(DospinosdbContext context,
                                      IInvokeStoredProcedure invokeSP) : IPhoneRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> UpdateAsync(UpdatePhoneDTO phoneDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", phoneDTO.EmployeeId},
                {"@number", phoneDTO.Number},
                {"@phoneType", phoneDTO.PhoneTypeId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdatePhone", parameters, false);
        }
    }
}