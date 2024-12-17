using DosPinos.HRMS.BusinessObjects.Interfaces.Rewards;
using DosPinos.HRMS.BusinessObjects.Resources.Rewards;
using DosPinos.HRMS.Entities.DTOs.Rewards;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class RewardService(IRewardRepository repository,
                               ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IRewardRepository _repository = repository;

        public async Task<IOperationResponseVO> CreateAsync(CreateRewardDTO rewardDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                if (rewardDTO.Amount < 1000) return this.CustomWarning("La recompensa debe ser de al menos ₡1.000,00. Por favor, ingresa un monto válido.");
                if (rewardDTO.Amount > 1000000) return this.CustomWarning("La recompensa debe ser menor a ₡1.000.000,00. Por favor, ingresa un monto válido.");

                rewardDTO.Date = DateOnly.FromDateTime(DateTime.Now);
                rewardDTO.Reason = RewardMessage.DefaultReason;

                bool result = await _repository.CreateAsync(rewardDTO);

                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {

                response = await this.HandlerLog(Module.Rewards, ActionCategory.Create, exception, rewardDTO);
            }

            return response;
        }
    }
}