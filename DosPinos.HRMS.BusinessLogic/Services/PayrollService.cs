using DosPinos.HRMS.BusinessObjects.Interfaces.Payroll;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class PayrollService(IPayrollRepository payrollRepository,
                                               ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IPayrollRepository _payrollRepository = payrollRepository;

        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                // Obtén los empleados activos
                List<int> activeEmployees = (List<int>)await _payrollRepository.GetAsync();

                foreach (var employeeId in activeEmployees)
                {
                    var responseRepository = await _payrollRepository.CreateAsync(employeeId);
                    if (responseRepository.Status != ResponseStatus.Success) response = responseRepository;
                }

                // Si hay algún warning en la respuesta, agrega el mensaje
                if (response.Status != ResponseStatus.Warning)
                    response = this.CustomWarning("El proceso se completó, pero se encontraron algunos errores durante la ejecución. Revise los detalles para más información.");

                // Obtén la última nómina
                response.Content = await _payrollRepository.GetAsync(DateTime.Now.Month, DateTime.Now.Year);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }

    }
}