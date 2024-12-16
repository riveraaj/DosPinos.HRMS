using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses;
using DosPinos.HRMS.Entities.DTOs.Employees.Addresses;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class AddressService(IAddressRepository repository,
                                ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IAddressRepository _repository = repository;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateAddressDTO addressDTO)
        {
            IOperationResponseVO response;
            try
            {
                response = await _repository.UpdateAsync(addressDTO);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Message.FirstOrDefault());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Update, exception, addressDTO);
            }

            return response;
        }
    }
}