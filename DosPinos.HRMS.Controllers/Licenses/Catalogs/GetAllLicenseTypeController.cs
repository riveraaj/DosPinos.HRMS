using DosPinos.HRMS.BusinessObjects.Interfaces.Licenses.Catalogs.LicenseTypes.InputPorts;

namespace DosPinos.HRMS.Controllers.Licenses.Catalogs
{
    public class GetAllLicenseTypeController(IGetAllLicenseTypeInputPort inputPort,
                                        IOutputPort outputPort)
    {
        private readonly IGetAllLicenseTypeInputPort _inputPort = inputPort;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO userId)
        {
            await _inputPort.GetAllAsync(userId);
            return _outputPort.OperationResponse;
        }
    }
}