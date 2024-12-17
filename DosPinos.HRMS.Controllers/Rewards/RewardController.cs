using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Rewards;

namespace DosPinos.HRMS.Controllers.Rewards
{
    public class RewardController(RewardService service)
    {
        private readonly RewardService _service = service;

        public async Task<IOperationResponseVO> CreateAsync(CreateRewardDTO rewardDTO)
            => await _service.CreateAsync(rewardDTO);
    }
}