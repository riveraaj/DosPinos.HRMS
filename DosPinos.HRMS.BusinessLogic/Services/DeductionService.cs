using DosPinos.HRMS.Entities.DTOs.Deductions;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class DeductionService(IDeductionRepository repository,
                                  ICreateLogIterator log) : BaseIterator(log)
    {
        private readonly IDeductionRepository _repository = repository;

        public async Task<IOperationResponseVO> CreateASync(CreateDeductionDTO deductionDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(deductionDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, deductionDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateDeductionDTO deductionDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.UpdateAsync(deductionDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Update, exception, deductionDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte deductionId, IEntityDTO entity)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.DeleteAsync(deductionId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}