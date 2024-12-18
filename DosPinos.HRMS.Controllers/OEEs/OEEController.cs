using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.OEEs;

namespace DosPinos.HRMS.Controllers.OEEs
{
    public class OEEController(OEEService service)
    {
        private readonly OEEService _service = service;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _service.GetAllAsync(entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateOEEDTO OEEDTO)
            => await _service.CreateAsync(OEEDTO);

        public async Task<IOperationResponseVO> DeleteAsync(int OEEId, IEntityDTO entity)
            => await _service.DeleteAsync(OEEId, entity);
    }
}