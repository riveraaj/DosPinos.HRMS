using DosPinos.HRMS.Entities.Interfaces.WorkingDays.Catalogs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.Catalogs.Holidays
{
    public interface IHolidayRepository
    {
        IEnumerable<IGetAllHolidayDTO> GetAll();
    }
}