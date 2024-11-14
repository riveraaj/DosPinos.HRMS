using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository,
                                 ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public async Task<IOperationResponseVO> GetAsync(int identification, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get employee
                var employee = await _employeeRepository.GetAsync(identification);

                if (employee == null) return this.CustomWarning("Lo sentimos, no se ha podido encontrar al empleado.");

                response.Content = employee;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Get, exception, entity);
            }

            return response;
        }
    }
}