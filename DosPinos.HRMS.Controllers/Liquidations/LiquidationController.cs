using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Liquidation;

namespace DosPinos.HRMS.Controllers.Liquidations
{
    public class LiquidationController(LiquidationService liquidation)
    {
        private readonly LiquidationService _liquidation = liquidation;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _liquidation.GetAllAsync(entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateLiquidationDTO liquidation)
            => await _liquidation.CreateAsync(liquidation);
    }
}