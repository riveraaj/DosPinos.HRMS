using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.FreeTimes;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class FreeTimeService(IFreeTimeRepository freeTimeRepository,
                                    ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IFreeTimeRepository _freeTimeRepository = freeTimeRepository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _freeTimeRepository.GetAllAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }
    }
}