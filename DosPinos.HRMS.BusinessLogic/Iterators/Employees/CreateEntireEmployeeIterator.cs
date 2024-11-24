using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees
{
    internal class CreateEntireEmployeeIterator(IEmployeeRepository employeeRepository,
                                                ICreateLogIterator createLogIterator,
                                                IOutputPort outputPort) : BaseIterator(createLogIterator),
                                                                          ICreateEntireEmployeeInputPort
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task CreateAsync(ICreateEntireEmployeeDTO employeeDTO)
        {
            IOperationResponseVO response;

            try
            {
                //Map employeeDTO
                ICreateEntireEmployeePOCO employee = EmployeeMapper.MapFrom(employeeDTO);

                //Validate POCO models
                List<Helpers.ValidationResult> validations = [
                    employee.Employee.ValidateModel(),
                    employee.Address.ValidateModel(),
                    employee.Compensation.ValidateModel(),
                    employee.Detail.ValidateModel(),
                    employee.Phone.ValidateModel()
                ];

                //Iterating on validations and handling errors
                foreach (var validation in validations)
                {
                    if (!validation.IsValid)
                    {
                        response = this.CustomWarning(validation.ErrorMessages);
                        _outputPort.Handle(response);
                        return;
                    }
                }

                //Create employee
                response = await _employeeRepository.CreateAsync(employee);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Message.FirstOrDefault());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, employeeDTO);
            }

            _outputPort.Handle(response);
        }
    }
}