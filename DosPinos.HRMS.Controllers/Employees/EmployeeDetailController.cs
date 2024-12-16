using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Employees.Details;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class EmployeeDetailController(EmployeeDetailService service)
    {
        private readonly EmployeeDetailService _service = service;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDetailDTO employeeDTO)
            => await _service.UpdateAsync(employeeDTO);
    }
}