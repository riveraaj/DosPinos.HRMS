using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.Commons.FreeTimes
{
    public class FreeTimeController(FreeTimeService service)
    {
        private readonly FreeTimeService _service = service;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _service.GetAllAsync(entity);
    }
}