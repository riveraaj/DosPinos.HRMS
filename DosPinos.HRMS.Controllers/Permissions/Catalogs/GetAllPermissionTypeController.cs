using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes.InputPorts;

namespace DosPinos.HRMS.Controllers.Permissions.Catalogs
{
    public class GetAllPermissionTypeController(IGetAllPermissionTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllPermissionTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}