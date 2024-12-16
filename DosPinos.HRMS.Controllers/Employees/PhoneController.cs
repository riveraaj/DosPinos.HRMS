using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Employees.Phones;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class PhoneController(PhoneService service)
    {
        private readonly PhoneService _service = service;

        public async Task<IOperationResponseVO> UpdateAsync(UpdatePhoneDTO phoneDTO)
            => await _service.UpdateAsync(phoneDTO);
    }
}