using DosPinos.HRMS.Entities.DTOs.Rewards;

namespace DosPinos.HRMS.EFCore.Mappers.Rewards
{
    internal static class RewardMapper
    {
        public static Reward MapFrom(CreateRewardDTO rewardDTO) => new()
        {
            Amount = rewardDTO.Amount,
            EmployeeId = rewardDTO.EmployeeId,
            Reason = rewardDTO.Reason,
            RewardDate = rewardDTO.Date,
        };
    }
}