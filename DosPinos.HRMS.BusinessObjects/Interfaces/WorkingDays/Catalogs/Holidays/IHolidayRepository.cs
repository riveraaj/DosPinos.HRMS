namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.Catalogs.Holidays
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<IGetAllHolidayDTO>> GetAllAsync();
    }
}