using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Dashboards;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class DashboardService(IDashboardRepository dashboardRepository,
                                 ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IDashboardRepository _dashboardRepository = dashboardRepository;

        public async Task<IOperationResponseVO> GetAllEmployeesVacationAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = _dashboardRepository.GetAllEmployeesVacationAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllActiveEmployeesAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = _dashboardRepository.GetAllActiveEmployeesAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllEmployeesLicenseAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = _dashboardRepository.GetAllEmployeesLicenseAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllCloseVacationAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = _dashboardRepository.GetAllCloseVacationAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllEmployeesExcessOvertimeAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = _dashboardRepository.GetAllEmployeesExcessOvertimeAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }
    }
}