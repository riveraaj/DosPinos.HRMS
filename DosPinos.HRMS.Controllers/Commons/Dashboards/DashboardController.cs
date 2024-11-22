using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.Commons.Dashboards
{
    public class DashboardController(DashboardService service)
    {
        private readonly DashboardService _service = service;

        public async Task<IOperationResponseVO> GetAllEmployeesVacationAsync(IEntityDTO entity)
            => await _service.GetAllEmployeesVacationAsync(entity);

        public async Task<IOperationResponseVO> GetAllActiveEmployeesAsync(IEntityDTO entity)
            => await _service.GetAllActiveEmployeesAsync(entity);

        public async Task<IOperationResponseVO> GetAllEmployeesLicenseAsync(IEntityDTO entity)
            => await _service.GetAllEmployeesLicenseAsync(entity);

        public async Task<IOperationResponseVO> GetAllCloseVacationAsync(IEntityDTO entity)
            => await _service.GetAllCloseVacationAsync(entity);

        public async Task<IOperationResponseVO> GetAllEmployeesExcessOvertimeAsync(IEntityDTO entity)
            => await _service.GetAllEmployeesExcessOvertimeAsync(entity);
    }
}