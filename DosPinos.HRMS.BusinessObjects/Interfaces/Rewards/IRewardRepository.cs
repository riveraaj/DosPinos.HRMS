using DosPinos.HRMS.Entities.DTOs.Rewards;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Rewards
{
    public interface IRewardRepository
    {
        Task<bool> CreateAsync(CreateRewardDTO rewardDTO);
    }
}