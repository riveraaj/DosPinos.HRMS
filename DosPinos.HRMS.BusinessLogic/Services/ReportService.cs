using DosPinos.HRMS.BusinessObjects.Interfaces.Reports;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class ReportService(IReportRepository reportRepository,
                                 ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IReportRepository _reportRepository = reportRepository;

        public async Task<IOperationResponseVO> GetAllOvertimeAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _reportRepository.GetAllOvertimeAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Reports, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllLicenseAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _reportRepository.GetAllLicenseAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Reports, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllSpecialPermissionAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _reportRepository.GetAllSpecialPermissionAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Reports, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllVacationAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _reportRepository.GetAllVacationAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Reports, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }
    }
}