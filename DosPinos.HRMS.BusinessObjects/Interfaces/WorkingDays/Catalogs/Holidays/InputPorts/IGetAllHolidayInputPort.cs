namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.Catalogs.Holidays.InputPorts
{
    public interface IGetAllHolidayInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}