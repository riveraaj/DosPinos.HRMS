using DosPinos.HRMS.Entities.DTOs.Holidays;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.Catalogs.Holidays
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<IGetAllHolidayDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateHolidayDTO holidayDTO);
        Task<IOperationResponseVO> UpdateAsync(UpdateHolidayDTO holidayDTO);
    }
}