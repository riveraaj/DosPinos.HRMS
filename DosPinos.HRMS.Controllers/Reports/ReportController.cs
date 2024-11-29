using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.Reports
{
    public class ReportController(ReportService service)
    {
        private readonly ReportService _service = service;

        public async Task<IOperationResponseVO> GetAllOvertimeAsync(IEntityDTO entity)
            => await _service.GetAllOvertimeAsync(entity);

        public async Task<IOperationResponseVO> GetAllVacationAsync(IEntityDTO entity)
            => await _service.GetAllVacationAsync(entity);

        public async Task<IOperationResponseVO> GetAllSpecialPermissionAsync(IEntityDTO entity)
            => await _service.GetAllSpecialPermissionAsync(entity);

        public async Task<IOperationResponseVO> GetAllLicenseAsync(IEntityDTO entity)
            => await _service.GetAllLicenseAsync(entity);
    }
}