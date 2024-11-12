using DosPinos.HRMS.BusinessObjects.Interfaces.Payroll;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class PayrollServiceIUserRepository(IPayrollRepository payrollRepository,
                                               ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IPayrollRepository _payrollRepository = payrollRepository;

        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get active employees
                List<int> activeEmployees = (List<int>)await _payrollRepository.GetAsync();

                activeEmployees.ForEach(async employeeId =>
                {
                    IOperationResponseVO responseRepository = await _payrollRepository.CreateAsync(employeeId);
                    if (responseRepository.Status != ResponseStatus.Success) response = responseRepository;
                });

                if (response.Status != ResponseStatus.Warning) response = this.CustomWarning("El proceso se completó, pero se encontraron algunos errores durante la ejecución. Revise los detalles para más información.");

                //Get last payroll
                response.Content = await _payrollRepository.GetAsync(DateTime.Now.Month, DateTime.Now.Year);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Security, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }
    }
}