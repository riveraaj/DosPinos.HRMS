using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones;
using DosPinos.HRMS.Entities.DTOs.Employees.Phones;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class PhoneService(IPhoneRepository repository,
                              ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IPhoneRepository _repository = repository;

        public async Task<IOperationResponseVO> UpdateAsync(UpdatePhoneDTO phoneDTO)
        {
            IOperationResponseVO response;
            try
            {
                response = await _repository.UpdateAsync(phoneDTO);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Message.FirstOrDefault());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Update, exception, phoneDTO);
            }

            return response;
        }
    }
}