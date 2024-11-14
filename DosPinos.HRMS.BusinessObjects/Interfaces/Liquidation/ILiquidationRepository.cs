using DosPinos.HRMS.Entities.DTOs.Liquidation;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Liquidation
{
    public interface ILiquidationRepository
    {
        Task<IEnumerable<GetAllLiquidationDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateLiquidationDTO liquidation);
    }
}