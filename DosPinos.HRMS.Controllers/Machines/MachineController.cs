using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.Machines
{
    public class MachineController(MachineService service)
    {
        private readonly MachineService _service = service;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _service.GetAllAsync(entity);
    }
}