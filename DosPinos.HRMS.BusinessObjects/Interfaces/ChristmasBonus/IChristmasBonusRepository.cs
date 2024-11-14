using DosPinos.HRMS.Entities.DTOs.ChristmasBonus;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.ChristmasBonus
{
    public interface IChristmasBonusRepository
    {
        Task<IEnumerable<int>> GetAllAsync();
        Task<IEnumerable<GetAllChristmasBonusDTO>> GetAsync(int year);
        Task<IOperationResponseVO> CreateAsync(int employeeId);
    }
}