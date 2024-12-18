using DosPinos.HRMS.BusinessObjects.Interfaces.OEEs;
using DosPinos.HRMS.Entities.DTOs.OEEs;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class OEEService(IOEERepository repository,
                            ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IOEERepository _repository = repository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _repository.GetAllAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.OEE, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateOEEDTO OEEDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(OEEDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.OEE, ActionCategory.GetAll, exception, OEEDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(int OEEId, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _repository.DeleteAsync(OEEId);
                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.OEE, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }
    }
}