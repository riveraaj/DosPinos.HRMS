using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Employees.Addresses;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class AddressController(AddressService service)
    {
        private readonly AddressService _service = service;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateAddressDTO employeeDTO)
            => await _service.UpdateAsync(employeeDTO);
    }
}