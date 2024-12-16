using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Employees.Compesations;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class EmployeeCompensationController(EmployeeCompensationService service)
    {
        private readonly EmployeeCompensationService _service = service;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeCompensationDTO employeeDTO)
            => await _service.UpdateAsync(employeeDTO);
    }
}
