using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.MaritalStatus.InputPorts;

namespace DosPinos.HRMS.Controllers.Employees.Catalogs.MaritalStatus
{
    public class GetAllMaritalStatusController(IGetAllMaritalStatusInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllMaritalStatusInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public IOperationResponseVO GetAll(IEntityDTO userId)
        {
            _inputPort.GetAll(userId);
            return _outputPort.OperationResponse;
        }
    }
}