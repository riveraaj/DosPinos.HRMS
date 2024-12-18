using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Employees;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class EmployeeController(EmployeeService employeeService)
    {
        private readonly EmployeeService _employeeService = employeeService;

        public async Task<IOperationResponseVO> GetAsync(int identification, IEntityDTO entity)
            => await _employeeService.GetAsync(identification, entity);

        public async Task<IOperationResponseVO> GetAllActiveAsync(IEntityDTO entity)
            => await _employeeService.GetAllActiveAsync(entity);

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _employeeService.GetAllAsync(entity);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDTO employeeDTO)
             => await _employeeService.UpdateAsync(employeeDTO);
    }
}