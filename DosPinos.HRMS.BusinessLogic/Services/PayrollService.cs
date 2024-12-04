using DosPinos.HRMS.BusinessObjects.Interfaces.Payroll;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class PayrollService(IPayrollRepository payrollRepository,
                                               ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IPayrollRepository _payrollRepository = payrollRepository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _payrollRepository.GetAsync(DateTime.Now.Month, DateTime.Now.Year);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                // get active employees
                List<int> activeEmployees = (List<int>)await _payrollRepository.GetAsync();

                foreach (var employeeId in activeEmployees)
                {
                    var responseRepository = await _payrollRepository.CreateAsync(employeeId);
                    if (responseRepository.Status != ResponseStatus.Success) response = responseRepository;
                }

                if (response.Status == ResponseStatus.Warning)
                    response = this.CustomWarning("El proceso se completó, pero se encontraron algunos errores durante la ejecución. Revise los detalles para más información.");
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(int employeeId, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response = await _payrollRepository.CreateAsync(employeeId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }
    }
}