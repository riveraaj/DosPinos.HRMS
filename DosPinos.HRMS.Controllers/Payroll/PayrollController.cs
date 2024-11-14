using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.Payroll
{
    public class PayrollController(PayrollService payrollService)
    {
        private readonly PayrollService _payrollService = payrollService;

        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
            => await _payrollService.CreateAsync(entity);
        public async Task<IOperationResponseVO> CreateAsync(int employeeId, IEntityDTO entity)
           => await _payrollService.CreateAsync(employeeId, entity);
    }
}