using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.InputPorts;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class GetAllEmployeeController(IGetAllEmployeeInputPort inputPort,
                                          IOutputPort outputPort)
    {
        private readonly IGetAllEmployeeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            await _inputPort.GetAllAsync(entity);
            return _outputPort.OperationResponse;
        }
    }
}