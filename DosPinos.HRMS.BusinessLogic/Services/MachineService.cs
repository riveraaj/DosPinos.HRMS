using DosPinos.HRMS.BusinessObjects.Interfaces.Machines;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class MachineService(IMachineRepository repository,
                            ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IMachineRepository _repository = repository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                response.Content = await _repository.GetAllAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }
    }
}