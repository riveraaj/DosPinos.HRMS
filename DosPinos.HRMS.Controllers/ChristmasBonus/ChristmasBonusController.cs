using DosPinos.HRMS.BusinessLogic.Services;

namespace DosPinos.HRMS.Controllers.ChristmasBonus
{
    public class ChristmasBonusController(ChristmasBonusService service)
    {
        private readonly ChristmasBonusService _service = service;
        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
            => await _service.CreateAsync(entity);
    }
}