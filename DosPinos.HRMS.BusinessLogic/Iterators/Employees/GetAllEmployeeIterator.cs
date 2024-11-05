using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees
{
    internal class GetAllEmployeeIterator(IEmployeeRepository employeeRepository,
                                          ICreateLogIterator createLogIterator,
                                          IOutputPort outputPort) : BaseIterator(createLogIterator),
                                                                    IGetAllEmployeeInputPort
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get vw for employees
                IEnumerable<IGetAllEmployeeDTO> employeeList = await _employeeRepository.GetAllAsync();
                response.Content = employeeList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Inquiries, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}