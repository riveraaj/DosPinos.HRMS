using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.InputPorts;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class CreateEmployeeController(ICreateEntireEmployeeInputPort inputPort,
                                   IOutputPort outputPort)
    {
        private readonly ICreateEntireEmployeeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> CreateAsync(ICreateEntireEmployeeDTO employeeDTO)
        {
            await _inputPort.CreateAsync(employeeDTO);
            return _outputPort.OperationResponse;
        }
    }
}