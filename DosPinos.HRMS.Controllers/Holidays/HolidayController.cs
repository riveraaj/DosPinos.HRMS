using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Holidays;

namespace DosPinos.HRMS.Controllers.Holidays
{
    public class HolidayController(HolidayService service)
    {
        private readonly HolidayService _service = service;

        public async Task<IOperationResponseVO> CreateAsync(CreateHolidayDTO holidayDTO)
            => await _service.CreateAsync(holidayDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateHolidayDTO holidayDTO)
            => await _service.UpdateAsync(holidayDTO);
    }
}