using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class EmployeeController(EmployeeService employeeService)
    {
        private readonly EmployeeService _employeeService = employeeService;

        public async Task<IOperationResponseVO> GetAsync(int identification, IEntityDTO entity)
            => await _employeeService.GetAsync(identification, entity);
    }
}