using DosPinos.HRMS.BusinessObjects.Interfaces.Rewards;
using DosPinos.HRMS.EFCore.Mappers.Rewards;
using DosPinos.HRMS.Entities.DTOs.Rewards;

namespace DosPinos.HRMS.EFCore.Repositories.Rewards
{
    internal class RewardRepository(DospinosdbContext context) : IRewardRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<bool> CreateAsync(CreateRewardDTO rewardDTO)
        {
            Reward reward = RewardMapper.MapFrom(rewardDTO);

            await _context.Rewards.AddAsync(reward);

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}