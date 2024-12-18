using DosPinos.HRMS.Entities.DTOs.IncomeTaxes;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class IncomeTaxService(IIncomeTaxRepository repository,
                            ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IIncomeTaxRepository _repository = repository;

        public async Task<IOperationResponseVO> GetAllTableAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                response.Content = await _repository.GetAllTableAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateASync(CreateIncomeTaxDTO incomeTaxDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(incomeTaxDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, incomeTaxDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateIncomeTaxDTO incomeTaxDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.UpdateAsync(incomeTaxDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, incomeTaxDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte incomeTaxId, IEntityDTO entity)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.DeleteAsync(incomeTaxId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}
